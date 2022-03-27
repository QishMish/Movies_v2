using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Services.Exceptions
{
    public class MovieAlreadyExistException : Exception
    {
        private const string errMessage = "Movie You Entered Already Exist";
        public MovieAlreadyExistException() : base(errMessage)
        {

        }
    }
}
