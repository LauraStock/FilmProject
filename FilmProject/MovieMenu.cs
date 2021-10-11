using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmProject.Controllers;

namespace FilmProject
{
    class MovieMenu
    {
        private readonly MovieController movieController;

        public MovieMenu(MovieController movieController)
        {
            this.movieController = movieController;
        }
        public void MenuLoop()
        {
            
            bool inMenu = true;
            while (inMenu)
            {
                //Console.Clear();
                Console.WriteLine("What would you like to do? \n1. Create new movie \n2. Read movies \n3. Delete movie \n4. Quit application");
                string[] MenuOptions = { "create", "read", "del", "quit" };
                int optionChoice = getUserOption(MenuOptions);

                
                switch (optionChoice)
                {
                    case 1:
                        movieController.CreateMovie();
                        break;
                    case 2:
                        movieController.ReadMovies();
                        break;
                    case 3:
                        movieController.DeleteMovies();
                        break;
                    default:
                        inMenu = false;
                        break;
                }


            }
        }
        
        public int getUserOption(string[] options)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            input = input.ToLower();
            for (int i = 1; i <= options.Length; i++)
            {

                if (input.Contains(i.ToString()) || input.Contains(options[i - 1]))
                { return i; }
            }
            return 0;
            //read user input and compare to options parameter -> output option number 
            //could use regex? to match options e.g for 1. Movies -> match 1, movie, movies, Mov etc
        }
    }
}
