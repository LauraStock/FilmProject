using FilmProject.Data;
using FilmProject.Exceptions;
using FilmProject.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProject.Services
{
    //This is the layer that takes input from Controller which has come from the user and checks it is in the right format etc. 
    // If this isn't the right format -> send back error message
    // If this does work -> talk to repository and db then return info from the database

    
    class MovieService
    {
        //List in this class simulates the db and can alter the list in this class but cannot change it in controller to keep it contained.
        // functions inside this class alter the list but the list gets returned to Controller as IEnumerable type so it can't be altered.
        
        private static int counter;
        private readonly MovieRepository repository;

        public MovieService(MovieRepository repository)
        {
            this.repository = repository;
            counter = 1;
        }
        

        public void Create(Movie movieToAdd)
        {
            movieToAdd.iD = counter;
            repository.Create(movieToAdd);
            counter++;
        }

        internal IEnumerable Read()
        {
            IEnumerable movieList = repository.Read();
            foreach (var item in movieList)
            {
                Console.WriteLine(item);
            }
            return movieList;
        }

        public void Delete(int delID)
        {
            if (!repository.Exists(delID))
            {
                throw new MovieNotFoundException();
            }
            else
            {
                repository.Delete(delID);
            }
        }

        internal void ReadByID(int delID)
        {
            if (!repository.Exists(delID))
            {
                throw new MovieNotFoundException();
            }
            else
            {
                repository.ReadByID(delID);
            }
            
        }

        /*
         * string[] filmGenres = { "action", "comedy", "drama", "fantasy", "horror", "mystery", "romance", "sci-fi", "thriller", "western" };
                foreach (var item in filmGenres)
                {
                    this._genre = (value.ToLower() == item) ? item : "Unknown";
                }
         * 
         * string[] ageRatingsUK = { "U","PG","12","12A","15","18","R18"};
                foreach (string item in ageRatingsUK)
                {
                    this._ageRating = (value.ToUpper() == item) ? item : "NA";
                }
         * 
         * 
         * _releaseDate = (value.Year >= 1878) ? value : new DateTime (0001,01,01);
         */
    }
}
