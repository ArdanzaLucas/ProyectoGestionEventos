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
    // guarda y lee ubicaciones en la tabla UBICATION
    public class UbicationRepository : IRepository<Ubication>
    {

        private static UbicationRepository instance;
        private SqliteDatabase database;

        private UbicationRepository()
        {
            database = SqliteDatabase.getInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static UbicationRepository getInstance()
        {
            if (instance == null)
            {
                instance = new UbicationRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void addToRepository(Ubication ubication)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO UBICATION (Name, Price, IsActive) VALUES (@name, @price, @isActive); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@name", ubication.Name);
                command.Parameters.AddWithValue("@price", ubication.Price);
                command.Parameters.AddWithValue("@isActive", ubication.IsActive);
                ubication.assignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        // solo los activos: los dados de baja se buscan con getById
        public List<Ubication> getAll()
        {
            List<Ubication> ubications = new List<Ubication>();

            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, IsActive FROM UBICATION WHERE IsActive = 1 ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ubications.Add(readUbication(reader));
                    }
                }
            }

            return ubications;
        }

        // si no existe, lanza NotFoundException
        public Ubication getById(int id)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, IsActive FROM UBICATION WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return readUbication(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro la ubicacion");
        }

        // guarda todos los datos, incluido IsActive para la baja logica
        public void update(int id, Ubication ubication)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE UBICATION SET Name = @name, Price = @price, IsActive = @isActive WHERE Id = @id";
                command.Parameters.AddWithValue("@name", ubication.Name);
                command.Parameters.AddWithValue("@price", ubication.Price);
                command.Parameters.AddWithValue("@isActive", ubication.IsActive);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // no se usa: el service hace baja logica, pero la interfaz lo pide
        public void removeById(int id)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM UBICATION WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private Ubication readUbication(SqliteDataReader reader)
        {
            return new Ubication(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetBoolean(3));
        }

    }
}
