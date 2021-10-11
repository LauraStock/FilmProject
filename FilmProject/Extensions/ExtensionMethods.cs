using FilmProject.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProject.Extensions
{
    static class ExtensionMethods
    {
        public static void ReadByID(this MovieRepository repo, int id)
        {
            //
            MySqlCommand command = repo.connection.CreateCommand();
            command.CommandText = "SELECT * FROM movies WHERE id=@id";
            command.Parameters.AddWithValue("@id", id);

            repo.connection.Open();
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetFieldValue<int>(0);
                string title = reader.GetFieldValue<string>(1);

                Movie movie = new Movie(title) { iD = id };
                Console.WriteLine(movie);
            }
            repo.connection.Close();
        }
        
        public static bool IsEven(this int i)
        {
            return (i % 2 == 0);
        }
        public static bool IsOdd(this int i)
        {
            return (i % 2 == 1);
        }
    }
}
