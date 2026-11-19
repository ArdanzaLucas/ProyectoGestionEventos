using Microsoft.Data.Sqlite;
using ProyectoPresupuestoEvento.Common;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    // guarda y lee etiquetas en la tabla MENU_TAG
    public class MenuTagRepository : IRemovableRepository<MenuTag>
    {

        private static MenuTagRepository instance;
        private SqliteDatabase database;

        private MenuTagRepository()
        {
            database = SqliteDatabase.GetInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static MenuTagRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuTagRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void AddToRepository(MenuTag menuTag)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO MENU_TAG (Description) VALUES (@description); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@description", menuTag.Description);
                menuTag.AssignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        public List<MenuTag> GetAll()
        {
            List<MenuTag> menuTags = new List<MenuTag>();

            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Description FROM MENU_TAG ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menuTags.Add(ReadMenuTag(reader));
                    }
                }
            }

            return menuTags;
        }

        // si no existe, lanza NotFoundException
        public MenuTag GetById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Description FROM MENU_TAG WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadMenuTag(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro la etiqueta");
        }

        public void Update(int id, MenuTag menuTag)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE MENU_TAG SET Description = @description WHERE Id = @id";
                command.Parameters.AddWithValue("@description", menuTag.Description);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM MENU_TAG WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private MenuTag ReadMenuTag(SqliteDataReader reader)
        {
            return new MenuTag(reader.GetInt32(0), reader.GetString(1));
        }

    }
}
