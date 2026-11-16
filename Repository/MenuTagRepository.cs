﻿using System;
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
    // guarda y lee etiquetas en la tabla MENU_TAG
    public class MenuTagRepository : IRepository<MenuTag>
    {

        private static MenuTagRepository instance;
        private SqliteDatabase database;

        private MenuTagRepository()
        {
            database = SqliteDatabase.getInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static MenuTagRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MenuTagRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void addToRepository(MenuTag menuTag)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO MENU_TAG (Description) VALUES (@description); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@description", menuTag.Description);
                menuTag.assignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        public List<MenuTag> getAll()
        {
            List<MenuTag> menuTags = new List<MenuTag>();

            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Description FROM MENU_TAG ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menuTags.Add(readMenuTag(reader));
                    }
                }
            }

            return menuTags;
        }

        // si no existe, lanza NotFoundException
        public MenuTag getById(int id)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Description FROM MENU_TAG WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return readMenuTag(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro la etiqueta");
        }

        public void update(int id, MenuTag menuTag)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE MENU_TAG SET Description = @description WHERE Id = @id";
                command.Parameters.AddWithValue("@description", menuTag.Description);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void removeById(int id)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM MENU_TAG WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private MenuTag readMenuTag(SqliteDataReader reader)
        {
            return new MenuTag(reader.GetInt32(0), reader.GetString(1));
        }

    }
}
