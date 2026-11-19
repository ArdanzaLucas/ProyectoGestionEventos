using Microsoft.Data.Sqlite;
using ProyectoPresupuestoEvento.Common;
using ProyectoPresupuestoEvento.Model;
using ProyectoPresupuestoEvento.Interface;

namespace ProyectoPresupuestoEvento.Repository
{
    // guarda y lee eventos en la tabla EVENT_ITEM
    public class EventItemRepository : IRemovableRepository<EventItem>
    {

        private static EventItemRepository instance;
        private SqliteDatabase database;

        private EventItemRepository()
        {
            database = SqliteDatabase.GetInstance();
        }


        // singleton: siempre devuelve la misma instancia
        public static EventItemRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new EventItemRepository();
            }
            return instance;
        }

        // inserta la fila y le pasa al objeto el id que asigno la base
        public void AddToRepository(EventItem eventItem)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO EVENT_ITEM (Name, ClientName, Date, GuestAdults, GuestChildren, Duration) "
                    + "VALUES (@name, @clientName, @date, @guestAdults, @guestChildren, @duration); SELECT last_insert_rowid();";
                AddParameters(command, eventItem);
                eventItem.AssignId(Convert.ToInt32(command.ExecuteScalar()));
            }
        }

        public List<EventItem> GetAll()
        {
            List<EventItem> eventItems = new List<EventItem>();

            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, ClientName, Date, GuestAdults, GuestChildren, Duration FROM EVENT_ITEM ORDER BY Id";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventItems.Add(ReadEventItem(reader));
                    }
                }
            }

            return eventItems;
        }

        // si no existe, lanza NotFoundException
        public EventItem GetById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, ClientName, Date, GuestAdults, GuestChildren, Duration FROM EVENT_ITEM WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadEventItem(reader);
                    }
                }
            }
            throw new NotFoundException("no se encontro el evento");
        }

        public void Update(int id, EventItem eventItem)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE EVENT_ITEM SET Name = @name, ClientName = @clientName, Date = @date, "
                    + "GuestAdults = @guestAdults, GuestChildren = @guestChildren, Duration = @duration WHERE Id = @id";
                AddParameters(command, eventItem);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        // la base borra tambien sus presupuestos por ON DELETE CASCADE
        public void RemoveById(int id)
        {
            using (SqliteConnection connection = database.GetConnection())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM EVENT_ITEM WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        private void AddParameters(SqliteCommand command, EventItem eventItem)
        {
            command.Parameters.AddWithValue("@name", eventItem.Name);
            command.Parameters.AddWithValue("@clientName", eventItem.ClientName);
            command.Parameters.AddWithValue("@date", eventItem.Date);
            command.Parameters.AddWithValue("@guestAdults", eventItem.GuestAdults);
            command.Parameters.AddWithValue("@guestChildren", eventItem.GuestChildren);
            command.Parameters.AddWithValue("@duration", eventItem.Duration);
        }

        // arma un objeto del modelo con una fila, en el orden de las columnas del SELECT
        private EventItem ReadEventItem(SqliteDataReader reader)
        {
            return new EventItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3),
                reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
        }

    }
}
