using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ProyectoPresupuestoEvento.Repository
{
    // acceso al archivo de la base; es singleton porque hay una sola base
    public class SqliteDatabase
    {
        private static SqliteDatabase instance;
        private string connectionString;


        //constructor

        private SqliteDatabase()
        {
            // la carpeta Data queda en la raiz del proyecto: tres carpetas arriba del ejecutable
            string carpeta = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data"));
            Directory.CreateDirectory(carpeta);

            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = Path.Combine(carpeta, "presupuestos.db");
            // activa las claves foraneas, necesarias para ON DELETE CASCADE
            builder.ForeignKeys = true;
            connectionString = builder.ToString();

            createTables();
        }


        //metodos

        public static SqliteDatabase getInstance()
        {
            if (instance == null)
            {
                instance = new SqliteDatabase();
            }
            return instance;
        }

        // devuelve una conexion abierta: quien la usa la cierra con using
        public SqliteConnection getConnection()
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }

        // crea las tablas solo si no existen, asi no se pierden los datos guardados
        private void createTables()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS UBICATION (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Price TEXT,
                    IsActive INTEGER
                );

                CREATE TABLE IF NOT EXISTS MENU (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Description TEXT,
                    PriceAdult TEXT,
                    PriceChild TEXT,
                    IsActive INTEGER
                );

                CREATE TABLE IF NOT EXISTS MENU_TAG (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Description TEXT UNIQUE COLLATE NOCASE
                );

                CREATE TABLE IF NOT EXISTS MENU_MENU_TAG (
                    MenuId INTEGER,
                    MenuTagId INTEGER,
                    PRIMARY KEY (MenuId, MenuTagId),
                    FOREIGN KEY (MenuId) REFERENCES MENU (Id) ON DELETE CASCADE,
                    FOREIGN KEY (MenuTagId) REFERENCES MENU_TAG (Id) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS OPTION_ITEM (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Price TEXT,
                    IsActive INTEGER
                );

                CREATE TABLE IF NOT EXISTS EVENT_ITEM (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    ClientName TEXT,
                    Date TEXT,
                    GuestAdults INTEGER,
                    GuestChilds INTEGER,
                    Duration INTEGER
                );

                CREATE TABLE IF NOT EXISTS QUOTE (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EventItemId INTEGER,
                    EventName TEXT,
                    EventClientName TEXT,
                    EventDate TEXT,
                    EventGuestAdults INTEGER,
                    EventGuestChilds INTEGER,
                    EventDuration INTEGER,
                    UbicationId INTEGER,
                    UbicationName TEXT,
                    UbicationPrice TEXT,
                    State INTEGER,
                    TotalUbication TEXT,
                    TotalMenus TEXT,
                    TotalOptionItems TEXT,
                    Total TEXT,
                    FOREIGN KEY (EventItemId) REFERENCES EVENT_ITEM (Id) ON DELETE CASCADE,
                    FOREIGN KEY (UbicationId) REFERENCES UBICATION (Id)
                );

                CREATE TABLE IF NOT EXISTS DETAIL_MENU (
                    QuoteId INTEGER,
                    MenuId INTEGER,
                    TagDescription TEXT,
                    MenuDescription TEXT,
                    AdultQuantity INTEGER,
                    ChildQuantity INTEGER,
                    UnitPriceAdult TEXT,
                    UnitPriceChild TEXT,
                    PRIMARY KEY (QuoteId, MenuId, TagDescription),
                    FOREIGN KEY (QuoteId) REFERENCES QUOTE (Id) ON DELETE CASCADE,
                    FOREIGN KEY (MenuId) REFERENCES MENU (Id)
                );

                CREATE TABLE IF NOT EXISTS DETAIL_OPTION_ITEM (
                    QuoteId INTEGER,
                    OptionItemId INTEGER,
                    OptionItemName TEXT,
                    UnitPrice TEXT,
                    PRIMARY KEY (QuoteId, OptionItemId),
                    FOREIGN KEY (QuoteId) REFERENCES QUOTE (Id) ON DELETE CASCADE,
                    FOREIGN KEY (OptionItemId) REFERENCES OPTION_ITEM (Id)
                );
            ";

            using (SqliteConnection connection = getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}
