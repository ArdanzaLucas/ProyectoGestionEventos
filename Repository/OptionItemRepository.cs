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
    // guarda y lee servicios adicionales en la tabla OPTION_ITEM
    public class OptionItemRepository : IRepository<OptionItem>
    {

        private static OptionItemRepository instance;
        private SqliteDatabase database;

        private OptionItemRepository()
        {
            database = SqliteDatabase.GetInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static OptionItemRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new OptionItemRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void AddToRepository(OptionItem optionItem)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO OPTION_ITEM (Name, Price, IsActive) VALUES (@name, @price, @isActive); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@name", optionItem.Name);
                command.Parameters.AddWithValue("@price", optionItem.Price);
                command.Parameters.AddWithValue("@isActive", optionItem.IsActive);
                optionItem.AssignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        // solo los activos: los dados de baja se buscan con getById
        public List<OptionItem> GetAll()
        {
            List<OptionItem> optionItems = new List<OptionItem>();

            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, IsActive FROM OPTION_ITEM WHERE IsActive = 1 ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        optionItems.Add(ReadOptionItem(reader));
                    }
                }
            }

            return optionItems;
        }

        // si no existe, lanza NotFoundException
        public OptionItem GetById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, IsActive FROM OPTION_ITEM WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadOptionItem(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro el servicio");
        }

        // guarda todos los datos, incluido IsActive para la baja logica
        public void Update(int id, OptionItem optionItem)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE OPTION_ITEM SET Name = @name, Price = @price, IsActive = @isActive WHERE Id = @id";
                command.Parameters.AddWithValue("@name", optionItem.Name);
                command.Parameters.AddWithValue("@price", optionItem.Price);
                command.Parameters.AddWithValue("@isActive", optionItem.IsActive);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }


        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private OptionItem ReadOptionItem(SqliteDataReader reader)
        {
            return new OptionItem(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetBoolean(3));
        }

    }
}
