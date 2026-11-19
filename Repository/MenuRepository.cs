using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using ProyectoPresupuestoEvento.Common;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    // guarda y lee los menus en la tabla MENU, y sus etiquetas en MENU_MENU_TAG
    public class MenuRepository : IRepository<Menu>
    {

        private static MenuRepository instance;
        private SqliteDatabase database;

        private MenuRepository()
        {
            database = SqliteDatabase.GetInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static MenuRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuRepository();
            }
            return instance;
        }

        // inserta el menu y sus etiquetas en una transaccion: se guarda todo o nada
        public void AddToRepository(Menu menu)
        {
            using (SqliteConnection connection = database.GetConnection())
            using (SqliteTransaction transaction = connection.BeginTransaction())
            {
                SqliteCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "INSERT INTO MENU (Description, PriceAdult, PriceChild, IsActive) VALUES (@description, @priceAdult, @priceChild, @isActive); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@description", menu.Description);
                command.Parameters.AddWithValue("@priceAdult", menu.PriceAdult);
                command.Parameters.AddWithValue("@priceChild", menu.PriceChild);
                command.Parameters.AddWithValue("@isActive", menu.IsActive);
                menu.AssignId(Convert.ToInt32(command.ExecuteScalar()));

                SaveTags(menu.Id, menu, connection, transaction);
                transaction.Commit();
            }
        }

        // solo los activos: los dados de baja se buscan con getById
        public List<Menu> GetAll()
        {
            List<Menu> menus = new List<Menu>();

            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Description, PriceAdult, PriceChild, IsActive FROM MENU WHERE IsActive = 1 ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menus.Add(ReadMenu(reader, connection));
                    }
                }
            }

            return menus;
        }

        // si no existe, lanza NotFoundException
        public Menu GetById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Description, PriceAdult, PriceChild, IsActive FROM MENU WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadMenu(reader, connection);
                    }
                }
            }
            throw new NotFoundException("no se encontro el menu");
        }

        // actualiza el menu, incluido IsActive, y vuelve a guardar sus etiquetas
        public void Update(int id, Menu menu)
        {
            using (SqliteConnection connection = database.GetConnection())
            using (SqliteTransaction transaction = connection.BeginTransaction())
            {
                SqliteCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "UPDATE MENU SET Description = @description, PriceAdult = @priceAdult, PriceChild = @priceChild, IsActive = @isActive WHERE Id = @id";
                command.Parameters.AddWithValue("@description", menu.Description);
                command.Parameters.AddWithValue("@priceAdult", menu.PriceAdult);
                command.Parameters.AddWithValue("@priceChild", menu.PriceChild);
                command.Parameters.AddWithValue("@isActive", menu.IsActive);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                SaveTags(id, menu, connection, transaction);
                transaction.Commit();
            }
        }


        // arma el menu y carga sus etiquetas con otra consulta sobre la misma conexion
        private Menu ReadMenu(SqliteDataReader reader, SqliteConnection connection)
        {
            int id = reader.GetInt32(0);
            List<MenuTag> tags = LoadTags(id, connection);
            return new Menu(id, reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), tags, reader.GetBoolean(4));
        }

        // lee las etiquetas del menu uniendo MENU_TAG con la tabla intermedia
        private List<MenuTag> LoadTags(int menuId, SqliteConnection connection)
        {
            List<MenuTag> tags = new List<MenuTag>();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MENU_TAG.Id, MENU_TAG.Description FROM MENU_TAG "
                + "INNER JOIN MENU_MENU_TAG ON MENU_MENU_TAG.MenuTagId = MENU_TAG.Id "
                + "WHERE MENU_MENU_TAG.MenuId = @menuId ORDER BY MENU_TAG.Id";
            command.Parameters.AddWithValue("@menuId", menuId);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tags.Add(new MenuTag(reader.GetInt32(0), reader.GetString(1)));
                }
            }

            return tags;
        }

        // borra las etiquetas guardadas del menu e inserta las actuales
        private void SaveTags(int menuId, Menu menu, SqliteConnection connection, SqliteTransaction transaction)
        {
            SqliteCommand delete = connection.CreateCommand();
            delete.Transaction = transaction;
            delete.CommandText = "DELETE FROM MENU_MENU_TAG WHERE MenuId = @menuId";
            delete.Parameters.AddWithValue("@menuId", menuId);
            delete.ExecuteNonQuery();

            foreach (MenuTag tag in menu.TagList)
            {
                SqliteCommand insert = connection.CreateCommand();
                insert.Transaction = transaction;
                insert.CommandText = "INSERT INTO MENU_MENU_TAG (MenuId, MenuTagId) VALUES (@menuId, @menuTagId)";
                insert.Parameters.AddWithValue("@menuId", menuId);
                insert.Parameters.AddWithValue("@menuTagId", tag.Id);
                insert.ExecuteNonQuery();
            }
        }

    }
}
