using FilmProject.Controllers;
using FilmProject.Data;
using FilmProject.Services;
using MySql.Data.MySqlClient;
using System;
using FilmProject.Extensions;

namespace FilmProject
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int i = 12;
            Console.WriteLine(i.IsEven());
            Console.WriteLine(i.IsOdd());
            */
            //bool connectionOpen = connection.Ping();

            //Console.WriteLine($"Connection status: {connection.State} \nPing successfull: {connectionOpen} \nDB Version: {connection.ServerVersion}");
            
            MySqlConnection connection = null;

            using (connection = MySqlUtils.GetConnection())
            {
                MovieRepository repo = new MovieRepository(connection);
                MovieService service = new MovieService(repo);
                MovieController controller = new MovieController(service);
                MovieMenu menu = new MovieMenu(controller);
                Console.WriteLine(menu);
                menu.MenuLoop();
            }
            /*
            try
            {
                connection = MySqlUtils.GetConnection();
                MovieRepository repo = new MovieRepository(connection);
                MovieService service = new MovieService(repo);
                MovieController controller = new MovieController(service);
                MovieMenu menu = new MovieMenu(controller);
                Console.WriteLine(menu);
                menu.MenuLoop();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
                Console.WriteLine("Connection closed.");
            }
            */
            
            
            
          
        }
        
    }
}
