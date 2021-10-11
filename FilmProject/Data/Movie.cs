using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProject.Data
{
    class Movie
    {
        //Properties
        public int iD { get; set; }
        public string title { get; set; }
        public string ageRating { get; set; }
        public int runTime { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
        public string actors { get; set; }
        public double rating { get; set; }
        public string director { get; set; }

        //Constructors - need a movie title at the very least
        public Movie(string title) : this (-1, title, new DateTime(0001,01,01), 0, "NA", "Unknown","Unknown",0,"Unknown")
        { }
        public Movie(int iD, string title, DateTime releaseDate, int runTime,string ageRating, string genre, string actors, double rating, string director)
        {
            this.iD = iD;
            this.title = title;
            this.releaseDate = releaseDate;
            this.runTime = runTime;
            this.ageRating = ageRating;
            this.genre = genre;
            this.actors = actors;
            this.rating = rating;
            this.director = director;
        }

        //Overrides
        public override string ToString()
        {
            string movieInfo = $"{this.iD}  -  {this.title}";
            return movieInfo;
        }
    }
}
