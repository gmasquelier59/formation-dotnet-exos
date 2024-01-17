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
    internal class OrderDAO : IDAOBase<Order>
    {
        public static List<Order> All()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = DbConnection.Get())
            {
                string query = "SELECT * FROM orders";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = CreateFromReader(reader);
                        if (order != null)
                            orders.Add(order);
                    }
                }
            }

            return orders;
        }

        public static bool Delete(Order order)
        {
            string query = "DELETE FROM orders WHERE order_id=@id;";

            using (SqlConnection connection = DbConnection.Get())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", order.Id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static Order? GetById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("id", "L'identifiant de la commande doit être strictement supérieur à 0");

            Order? order = null;

            using (SqlConnection connection = DbConnection.Get())
            {
                string query = "SELECT * FROM orders WHERE order_id=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        order = CreateFromReader(reader);
                }
            }

            return order;
        }

        public static Order Save(Order order, SqlTransaction transaction)
        {
            return Save(order, transaction.Connection, transaction);
        }

        public static Order Save(Order order)
        {
            using SqlConnection connection = DbConnection.Get();
            return Save(order, connection, null);
        }

        private static Order Save(Order order, SqlConnection connection, SqlTransaction transaction = null)
        {
            bool toBeCreated = order.Id == 0;
            string query;

            if (toBeCreated)
                query = "INSERT INTO orders (client_id, order_date, total) OUTPUT inserted.order_id VALUES (@client_id, @order_date, @total);";
            else
                query = "UPDATE orders SET client_id=@client_id, order_date=@order_date, total=@total WHERE order_id=@id;";

            SqlCommand command;
            if (transaction == null)
                command = new SqlCommand(query, connection);
            else
                command = new SqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@client_id", order.Client.Id);
            command.Parameters.AddWithValue("@order_date", order.Date);
            command.Parameters.AddWithValue("@total", order.Total);

            if (toBeCreated)
            {
                int newId = (int)command.ExecuteScalar();
                order.Id = newId;
            }
            else
            {
                command.Parameters.AddWithValue("@id", order.Id);
                command.ExecuteNonQuery();
            }

            return order;
        }

        private static Order? CreateFromReader(SqlDataReader reader)
        {
            if (reader.IsClosed)
                return null;

            Client client = ClientDAO.GetById(reader.GetInt32("client_id"));

            if (client == null)
                return null;

            return new Order(reader.GetInt32("order_id"), client, reader.GetDateTime("order_date"), reader.GetDecimal("total"));
        }
    }
}
