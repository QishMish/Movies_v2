using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Services.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        private const string errMessage = "Movie Not Found";
        public MovieNotFoundException() : base(errMessage)
        {

        }
    }
}
