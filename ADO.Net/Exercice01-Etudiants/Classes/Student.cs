using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01_Etudiants.Classes
{
    internal class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public int Classroom { get; set; }
        public DateOnly GraduationDate { get; set; } = DateOnly.MinValue;

        public Student(string name, string firstname, int classroom, DateOnly graduationDate)
        {
            Name = name;
            Firstname = firstname;
            Classroom = classroom;
            GraduationDate = graduationDate;
        }

        private Student(Guid id, string name, string firstname, int classroom, DateOnly graduationDate)
        {
            Id = id;
            Name = name;
            Firstname = firstname;
            Classroom = classroom;
            GraduationDate = graduationDate;
        }

        public static Student GetById(Guid id)
        {
            using (SqlConnection connection = DbContext.GetConnection())
            {
                string query = "SELECT * FROM etudiants WHERE id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Student student = new Student(reader.GetGuid("id"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetInt16("classe"), (!reader.IsDBNull("date_diplome") ? DateOnly.FromDateTime(reader.GetDateTime("date_diplome")) : DateOnly.MinValue));
                    return student;
                }
            }

            return null;
        }

        public static List<Student> All()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = DbContext.GetConnection())
            {
                string query = "SELECT * FROM etudiants ORDER BY nom, prenom";
                SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader();
                while (reader.Read())
                {
                    Student studient = new Student(reader.GetGuid("id"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetInt16("classe"), (!reader.IsDBNull("date_diplome") ? DateOnly.FromDateTime(reader.GetDateTime("date_diplome")) : DateOnly.MinValue));
                    students.Add(studient);
                }
            }

            return students;
        }

        public void Save()
        {
            using (SqlConnection connection = DbContext.GetConnection())
            {
                string query = "INSERT INTO etudiants (nom, prenom, classe, date_diplome) VALUES (@name, @firstname, @classroom, @graduationdate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@firstname", Firstname);
                command.Parameters.AddWithValue("@classroom", Classroom);
                command.Parameters.Add("@graduationdate", SqlDbType.Date).Value = GraduationDate.Equals(DateOnly.MinValue) ? DBNull.Value : GraduationDate;

                command.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (SqlConnection connection = DbContext.GetConnection())
            {
                string query = "UPDATE etudiants SET nom=@name, prenom=@firstname, classe=@classroom, date_diplome=@graduationdate WHERE id=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("id", System.Data.SqlDbType.UniqueIdentifier).Value = Id;
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@firstname", Firstname);
                command.Parameters.AddWithValue("@classroom", Classroom);
                command.Parameters.Add("@graduationdate", SqlDbType.Date).Value = GraduationDate.Equals(DateOnly.MinValue) ? DBNull.Value : GraduationDate;

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteById(string id)
        {
            DeleteById(new Guid(id));
        }

        public static void DeleteById(Guid id)
        {
            using (SqlConnection connection = DbContext.GetConnection())
            {
                string query = "DELETE FROM etudiants WHERE id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("id", System.Data.SqlDbType.UniqueIdentifier).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteAll()
        {
            using (SqlConnection connection = DbContext.GetConnection())
            {
                string query = "DELETE FROM etudiants";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
