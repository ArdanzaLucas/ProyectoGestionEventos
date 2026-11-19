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
    // guarda y lee los presupuestos con sus lineas de catering y de servicios
    public class QuoteRepository : IRepository<Quote>
    {

        private static QuoteRepository instance;
        private SqliteDatabase database;

        private QuoteRepository()
        {
            database = SqliteDatabase.GetInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static QuoteRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new QuoteRepository();
            }
            return instance;
        }

        // inserta el presupuesto y sus lineas en una transaccion: se guarda todo o nada
        public void AddToRepository(Quote quote)
        {
            using (SqliteConnection connection = database.GetConnection())
            using (SqliteTransaction transaction = connection.BeginTransaction())
            {
                SqliteCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "INSERT INTO QUOTE (EventItemId, EventName, EventClientName, EventDate, EventGuestAdults, EventGuestChildren, EventDuration, "
                    + "LocationId, LocationName, LocationPrice, State, TotalLocation, TotalMenus, TotalOptionItems, Total) "
                    + "VALUES (@eventItemId, @eventName, @eventClientName, @eventDate, @eventGuestAdults, @eventGuestChildren, @eventDuration, "
                    + "@locationId, @locationName, @locationPrice, @state, @totalLocation, @totalMenus, @totalOptionItems, @total); "
                    + "SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@eventItemId", quote.EventItemId);
                AddParameters(command, quote);
                quote.AssignId(Convert.ToInt32(command.ExecuteScalar()));

                SaveDetails(quote.Id, quote, connection, transaction);
                transaction.Commit();
            }
        }

        public List<Quote> GetAll()
        {
            List<Quote> quotes = new List<Quote>();

            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, EventItemId, EventName, EventClientName, EventDate, EventGuestAdults, EventGuestChildren, EventDuration, "
                    + "LocationId, LocationName, LocationPrice, State, TotalLocation, TotalMenus, TotalOptionItems, Total FROM QUOTE ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quotes.Add(ReadQuote(reader, connection));
                    }
                }
            }

            return quotes;
        }

        // si no existe, lanza NotFoundException
        public Quote GetById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, EventItemId, EventName, EventClientName, EventDate, EventGuestAdults, EventGuestChildren, EventDuration, "
                    + "LocationId, LocationName, LocationPrice, State, TotalLocation, TotalMenus, TotalOptionItems, Total FROM QUOTE WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadQuote(reader, connection);
                    }
                }
            }
            throw new NotFoundException("no se encontro el presupuesto");
        }

        // actualiza el presupuesto, incluido su estado, y reemplaza sus lineas
        public void Update(int id, Quote quote)
        {
            using (SqliteConnection connection = database.GetConnection())
            using (SqliteTransaction transaction = connection.BeginTransaction())
            {
                SqliteCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "UPDATE QUOTE SET EventName = @eventName, EventClientName = @eventClientName, EventDate = @eventDate, "
                    + "EventGuestAdults = @eventGuestAdults, EventGuestChildren = @eventGuestChildren, EventDuration = @eventDuration, "
                    + "LocationId = @locationId, LocationName = @locationName, LocationPrice = @locationPrice, State = @state, "
                    + "TotalLocation = @totalLocation, TotalMenus = @totalMenus, TotalOptionItems = @totalOptionItems, Total = @total WHERE Id = @id";
                AddParameters(command, quote);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                SaveDetails(id, quote, connection, transaction);
                transaction.Commit();
            }
        }

        // sus lineas se borran solas por ON DELETE CASCADE
        public void RemoveById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM QUOTE WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        private void AddParameters(SqliteCommand command, Quote quote)
        {
            command.Parameters.AddWithValue("@eventName", quote.EventName);
            command.Parameters.AddWithValue("@eventClientName", quote.EventClientName);
            command.Parameters.AddWithValue("@eventDate", quote.EventDate);
            command.Parameters.AddWithValue("@eventGuestAdults", quote.EventGuestAdults);
            command.Parameters.AddWithValue("@eventGuestChildren", quote.EventGuestChildren);
            command.Parameters.AddWithValue("@eventDuration", quote.EventDuration);
            command.Parameters.AddWithValue("@locationId", quote.Location.Id);
            command.Parameters.AddWithValue("@locationName", quote.LocationName);
            command.Parameters.AddWithValue("@locationPrice", quote.LocationPrice);
            command.Parameters.AddWithValue("@state", (int)quote.State);
            command.Parameters.AddWithValue("@totalLocation", quote.TotalLocation);
            command.Parameters.AddWithValue("@totalMenus", quote.TotalMenus);
            command.Parameters.AddWithValue("@totalOptionItems", quote.TotalOptionItems);
            command.Parameters.AddWithValue("@total", quote.Total);
        }

        // arma el presupuesto con sus copias congeladas
        private Quote ReadQuote(SqliteDataReader reader, SqliteConnection connection)
        {
            int id = reader.GetInt32(0);
            Location location = LocationRepository.GetInstance().GetById(reader.GetInt32(8));
            List<DetailMenu> menus = LoadDetailMenus(id, connection);
            List<DetailOptionItem> optionItems = LoadDetailOptionItems(id, connection);

            // constructor de lectura: recibe las copias guardadas, no los datos actuales
            Quote quote = new Quote(id, (QuoteState)reader.GetInt32(11),
                reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4),
                reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7),
                location, reader.GetString(9), reader.GetDecimal(10),
                menus, optionItems,
                reader.GetDecimal(12), reader.GetDecimal(13), reader.GetDecimal(14), reader.GetDecimal(15));
            return quote;
        }

        // cada linea se arma con el menu real y los datos congelados guardados
        private List<DetailMenu> LoadDetailMenus(int quoteId, SqliteConnection connection)
        {
            List<DetailMenu> menus = new List<DetailMenu>();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MenuId, TagDescription, MenuDescription, AdultQuantity, ChildQuantity, UnitPriceAdult, UnitPriceChild "
                + "FROM DETAIL_MENU WHERE QuoteId = @quoteId";
            command.Parameters.AddWithValue("@quoteId", quoteId);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Menu menu = MenuRepository.GetInstance().GetById(reader.GetInt32(0));
                    DetailMenu detailMenu = new DetailMenu(menu, reader.GetString(2), reader.GetString(1), reader.GetInt32(3), reader.GetInt32(4),
                        reader.GetDecimal(5), reader.GetDecimal(6));
                    menus.Add(detailMenu);
                }
            }

            return menus;
        }

        // igual que las lineas de catering, con el servicio real y su nombre y precio congelados
        private List<DetailOptionItem> LoadDetailOptionItems(int quoteId, SqliteConnection connection)
        {
            List<DetailOptionItem> optionItems = new List<DetailOptionItem>();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT OptionItemId, OptionItemName, UnitPrice FROM DETAIL_OPTION_ITEM WHERE QuoteId = @quoteId";
            command.Parameters.AddWithValue("@quoteId", quoteId);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    OptionItem optionItem = OptionItemRepository.GetInstance().GetById(reader.GetInt32(0));
                    DetailOptionItem detailOptionItem = new DetailOptionItem(optionItem, reader.GetString(1), reader.GetDecimal(2));
                    optionItems.Add(detailOptionItem);
                }
            }

            return optionItems;
        }

        // borra las lineas guardadas del presupuesto e inserta las actuales
        private void SaveDetails(int quoteId, Quote quote, SqliteConnection connection, SqliteTransaction transaction)
        {
            SqliteCommand deleteMenus = connection.CreateCommand();
            deleteMenus.Transaction = transaction;
            deleteMenus.CommandText = "DELETE FROM DETAIL_MENU WHERE QuoteId = @quoteId";
            deleteMenus.Parameters.AddWithValue("@quoteId", quoteId);
            deleteMenus.ExecuteNonQuery();

            SqliteCommand deleteOptionItems = connection.CreateCommand();
            deleteOptionItems.Transaction = transaction;
            deleteOptionItems.CommandText = "DELETE FROM DETAIL_OPTION_ITEM WHERE QuoteId = @quoteId";
            deleteOptionItems.Parameters.AddWithValue("@quoteId", quoteId);
            deleteOptionItems.ExecuteNonQuery();

            foreach (DetailMenu detailMenu in quote.MenusList)
            {
                SqliteCommand insert = connection.CreateCommand();
                insert.Transaction = transaction;
                insert.CommandText = "INSERT INTO DETAIL_MENU (QuoteId, MenuId, TagDescription, MenuDescription, AdultQuantity, ChildQuantity, UnitPriceAdult, UnitPriceChild) "
                    + "VALUES (@quoteId, @menuId, @tagDescription, @menuDescription, @adultQuantity, @childQuantity, @unitPriceAdult, @unitPriceChild)";
                insert.Parameters.AddWithValue("@quoteId", quoteId);
                insert.Parameters.AddWithValue("@menuId", detailMenu.Menu.Id);
                insert.Parameters.AddWithValue("@tagDescription", detailMenu.TagDescription);
                insert.Parameters.AddWithValue("@menuDescription", detailMenu.MenuDescription);
                insert.Parameters.AddWithValue("@adultQuantity", detailMenu.AdultQuantity);
                insert.Parameters.AddWithValue("@childQuantity", detailMenu.ChildQuantity);
                insert.Parameters.AddWithValue("@unitPriceAdult", detailMenu.UnitPriceAdult);
                insert.Parameters.AddWithValue("@unitPriceChild", detailMenu.UnitPriceChild);
                insert.ExecuteNonQuery();
            }

            foreach (DetailOptionItem detailOptionItem in quote.OptionItemList)
            {
                SqliteCommand insert = connection.CreateCommand();
                insert.Transaction = transaction;
                insert.CommandText = "INSERT INTO DETAIL_OPTION_ITEM (QuoteId, OptionItemId, OptionItemName, UnitPrice) "
                    + "VALUES (@quoteId, @optionItemId, @optionItemName, @unitPrice)";
                insert.Parameters.AddWithValue("@quoteId", quoteId);
                insert.Parameters.AddWithValue("@optionItemId", detailOptionItem.OptionItem.Id);
                insert.Parameters.AddWithValue("@optionItemName", detailOptionItem.OptionItemName);
                insert.Parameters.AddWithValue("@unitPrice", detailOptionItem.UnitPrice);
                insert.ExecuteNonQuery();
            }
        }

    }
}
