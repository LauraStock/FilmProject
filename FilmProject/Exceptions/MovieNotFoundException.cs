using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProject.Exceptions
{
    class MovieNotFoundException : Exception
    {
        public MovieNotFoundException() : base()
        { }
        
        public MovieNotFoundException(string message) : base(message)
        { }

    }
}
