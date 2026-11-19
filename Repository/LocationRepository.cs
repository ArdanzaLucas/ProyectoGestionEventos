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
    // guarda y lee ubicaciones en la tabla LOCATION
    public class LocationRepository : IRepository<Location>
    {

        private static LocationRepository instance;
        private SqliteDatabase database;

        private LocationRepository()
        {
            database = SqliteDatabase.GetInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static LocationRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new LocationRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void AddToRepository(Location location)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO LOCATION (Name, Price, IsActive) VALUES (@name, @price, @isActive); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@name", location.Name);
                command.Parameters.AddWithValue("@price", location.Price);
                command.Parameters.AddWithValue("@isActive", location.IsActive);
                location.AssignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        // solo los activos: los dados de baja se buscan con getById
        public List<Location> GetAll()
        {
            List<Location> locations = new List<Location>();

            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, IsActive FROM LOCATION WHERE IsActive = 1 ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        locations.Add(ReadLocation(reader));
                    }
                }
            }

            return locations;
        }

        // si no existe, lanza NotFoundException
        public Location GetById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, IsActive FROM LOCATION WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadLocation(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro la ubicacion");
        }

        // guarda todos los datos, incluido IsActive para la baja logica
        public void Update(int id, Location location)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE LOCATION SET Name = @name, Price = @price, IsActive = @isActive WHERE Id = @id";
                command.Parameters.AddWithValue("@name", location.Name);
                command.Parameters.AddWithValue("@price", location.Price);
                command.Parameters.AddWithValue("@isActive", location.IsActive);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // no se usa: el service hace baja logica, pero la interfaz lo pide
        public void RemoveById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM LOCATION WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private Location ReadLocation(SqliteDataReader reader)
        {
            return new Location(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetBoolean(3));
        }

    }
}
