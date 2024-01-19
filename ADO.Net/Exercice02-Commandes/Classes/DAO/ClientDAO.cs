using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace Exercice02_Commandes.Classes.DAO
{
    internal class ClientDAO : IBaseDAO<Client>
    {
        public static List<Client> All()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection connection = DbConnection.Get())
            {
                string query = "SELECT * FROM clients";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = CreateFromReader(reader);
                        if (client != null)
                            clients.Add(client);
                    }
                }
            }

            return clients;
        }

        public static bool Delete(Client client)
        {
            string query = "DELETE FROM clients WHERE client_id=@id;";

            using (SqlConnection connection = DbConnection.Get())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", client.Id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static Client? GetById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id", "L'identifiant du client doit être strictement supérieur à 0");

            Client? client = null;

            using (SqlConnection connection = DbConnection.Get())
            {
                string query = "SELECT * FROM clients WHERE client_id=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = CreateFromReader(reader);

                    }
                }
            }

            return client;
        }

        public static Client Save(Client client)
        {
            using (SqlConnection connection = DbConnection.Get())
            {
                SqlTransaction transaction = connection.BeginTransaction();

                bool toBeCreated = client.Id == 0;
                string query;

                if (toBeCreated)
                    query = "INSERT INTO clients (name, firstname, address, address_zip, address_city, phone) OUTPUT inserted.client_id VALUES (@name, @firstname, @address, @address_zip, @address_city, @phone);";
                else
                    query = "UPDATE clients SET name=@name, firstname=@firstname, address=@address, address_zip=@address_zip, address_city=@address_city, phone=@phone WHERE client_id=@id;";

                SqlCommand command = new SqlCommand(query, connection, transaction);

                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@firstname", client.Firstname);
                command.Parameters.AddWithValue("@address", client.Address);
                command.Parameters.AddWithValue("@address_zip", client.AddressZip);
                command.Parameters.AddWithValue("@address_city", client.AddressCity);
                command.Parameters.AddWithValue("@phone", client.Phone);

                if (toBeCreated)
                {
                    int newId = (int)command.ExecuteScalar();
                    client.Id = newId;
                }
                else
                {
                    command.Parameters.AddWithValue("@id", client.Id);
                    command.ExecuteNonQuery();
                }

                foreach (Order order in client.Orders)
                    OrderDAO.Save(order, transaction);

                transaction.Commit();

                return client;
            }
        }

        public static Client? CreateFromReader(SqlDataReader reader)
        {
            if (reader.IsClosed)
                return null;

            return new Client(reader.GetInt32("client_id"), reader.GetString("name"), reader.GetString("firstname"), reader.GetString("address"), reader.GetString("address_zip"), reader.GetString("address_city"), reader.GetString("phone"));
        }
    }
}
