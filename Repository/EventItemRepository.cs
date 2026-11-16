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
    // guarda y lee eventos en la tabla EVENT_ITEM
    public class EventItemRepository : IRepository<EventItem>
    {

        private static EventItemRepository instance;
        private SqliteDatabase database;

        private EventItemRepository()
        {
            database = SqliteDatabase.getInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static EventItemRepository getInstance()
        {
            if (instance == null)
            {
                instance = new EventItemRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void addToRepository(EventItem eventItem)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO EVENT_ITEM (Name, ClientName, Date, GuestAdults, GuestChilds, Duration) "
                    + "VALUES (@name, @clientName, @date, @guestAdults, @guestChilds, @duration); SELECT last_insert_rowid();";
                addParameters(command, eventItem);
                eventItem.assignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        public List<EventItem> getAll()
        {
            List<EventItem> eventItems = new List<EventItem>();

            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, ClientName, Date, GuestAdults, GuestChilds, Duration FROM EVENT_ITEM ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventItems.Add(readEventItem(reader));
                    }
                }
            }

            return eventItems;
        }

        // si no existe, lanza NotFoundException
        public EventItem getById(int id)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, ClientName, Date, GuestAdults, GuestChilds, Duration FROM EVENT_ITEM WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return readEventItem(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro el evento");
        }

        public void update(int id, EventItem eventItem)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE EVENT_ITEM SET Name = @name, ClientName = @clientName, Date = @date, "
                    + "GuestAdults = @guestAdults, GuestChilds = @guestChilds, Duration = @duration WHERE Id = @id";
                addParameters(command, eventItem);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // la base borra tambien sus presupuestos por ON DELETE CASCADE
        public void removeById(int id)
        {
            using (SqliteConnection connection = database.getConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM EVENT_ITEM WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        private void addParameters(SqliteCommand command, EventItem eventItem)
        {
            command.Parameters.AddWithValue("@name", eventItem.Name);
            command.Parameters.AddWithValue("@clientName", eventItem.ClientName);
            command.Parameters.AddWithValue("@date", eventItem.Date);
            command.Parameters.AddWithValue("@guestAdults", eventItem.GuestAdults);
            command.Parameters.AddWithValue("@guestChilds", eventItem.GuestChilds);
            command.Parameters.AddWithValue("@duration", eventItem.Duration);
        }

        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private EventItem readEventItem(SqliteDataReader reader)
        {
            return new EventItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3),
                reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
        }

    }
}
