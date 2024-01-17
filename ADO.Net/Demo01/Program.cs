using Microsoft.Data.SqlClient;

string connectionString = "Data Source=(localdb)\\M2I; Database=contactDB";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    string query = "INSERT INTO Contact (nom, prenom, email) VALUES (@nom, @prenom, @email)";

    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@nom", "masquelier");
    command.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = "truc@machin.fr";
    command.Parameters.AddWithValue("@prenom", "guillaume");

    try
    {
        connection.Open();

        command.ExecuteNonQuery();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}