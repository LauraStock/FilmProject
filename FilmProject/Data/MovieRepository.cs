using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FilmProject.Data
{
    class MovieRepository
    {
        private static IList<Movie> movies;
        private static string schemaPath;
        public MySqlConnection connection { get; }

        public MovieRepository(MySqlConnection connection)
        {
            movies = new List<Movie>();
            schemaPath = "./" + @"\Resources\schema.sql";
            this.connection = connection;
            
        }

        internal void Create(Movie movie)
        {
            Console.WriteLine("We are in the repository - create");
            using StreamWriter writer = File.AppendText(schemaPath);
            writer.WriteLine($"INSERT INTO movies(movieName) VALUES ('{movie.title}')");
            writer.Flush();
            writer.Dispose();

            connection.Open();
            MySqlUtils.RunSchema(schemaPath, connection);
            connection.Close();
            movies.Add(movie);
            
        }

        internal IEnumerable Read()
        {
            
            IList movieList = new List<Movie>();
            
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM movies";

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>(0);
                string title = reader.GetFieldValue<string>(1);

                Movie movie = new Movie(title) { iD = id};
                movieList.Add(movie);
            }
            connection.Close();
            
            return movieList;
        }

        internal void Delete(int delID)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM movies WHERE id=@id";
            command.Parameters.AddWithValue("@id", delID);

            connection.Open();
            command.Prepare();
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Item successfully deleted");

            
        }

        internal bool Exists(int delID)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM movies WHERE id=@id";
            command.Parameters.AddWithValue("@id", delID);

            connection.Open();
            command.Prepare();
            int result = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return result > 0;

        }

    }
}
