using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_Commandes.Classes
{
    internal class DbConnection
    {
        private static readonly string connectionString = "Data Source=(localdb)\\M2I; Integrated Security=True; Database=Boutique";

        public static SqlConnection Get()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);  
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
