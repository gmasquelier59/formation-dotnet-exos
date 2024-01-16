using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01_Etudiants.Classes
{
    internal static class DbContext
    {
        public static string DbConnectionString = "Data Source=(localdb)\\M2I; Database=Exercice01";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(DbConnectionString);
            connection.Open();
            return connection;
        }
    }
}
