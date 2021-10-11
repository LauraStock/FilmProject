using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmProject.Data;
using FilmProject.Exceptions;
using FilmProject.Services;

namespace FilmProject.Controllers
{
    class MovieController
    {
        private readonly IList<Movie> movies;
        private readonly MovieService service;

        public MovieController(MovieService service)
        {
            this.movies = new List<Movie>();
            this.service = service;
        } 

        public void CreateMovie()
        {
            //Get user input for all the movie films then create new movie object and send to service
            Console.WriteLine("What movie would you like to add?");
            string title = Console.ReadLine();
            Movie movieToAdd = new Movie(title);
            //Console.WriteLine("Would you like to add any other information?");


            /*
            string[] gatherMovieData = { "1. No thanks",
                                        "2. Run time (minutes)", 
                                        "3. Age Rating \n1. U\n2. PG \n3. 12 \n4. 12A \n5. 15 \n6. 18 \n7. R18", 
                                        "4. Main Actor", 
                                        "5. Director", 
                                        "6. Release Date (dd/mm/yyyy)",
                                        "7. Genre \n1. Action \n2. Comedy \n 3. Drama \n4. Fantasy \n5. Horror \n6. Mystery \n7. Romance \n8. Sci-fi \n9. Thriller \n10. Western",
                                        "8. Rating" };
            string[] movieData
            foreach
            */
            
            Console.WriteLine($"Film to add is {movieToAdd}");
            service.Create(movieToAdd);
        }
        public void ReadMovies()
        {
            Console.WriteLine("To read all films enter 0 or enter the ID of the film you want to read.");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 0)
            {
                service.Read();
            }
            else
            {
                service.ReadByID(input);
            }
            //view all movies? or just a particular one?
                        
        }
        public void DeleteMovies()
        {
            //view movies first?
            Console.WriteLine("Please enter the ID number of the film you want to delete.");
            int delID = Convert.ToInt32(Console.ReadLine());
            try
            {
                service.Delete(delID);
            }
            catch (MovieNotFoundException e)
            {
                Console.WriteLine($"The film with ID={delID} could not be found.");
            }
            
        }
    }
}
