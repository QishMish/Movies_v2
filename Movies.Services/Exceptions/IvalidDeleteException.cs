using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Services.Exceptions
{
    public class InvalidDeleteException : Exception
    {
        private const string errMessage = "Can Not Delete User";
        public InvalidDeleteException() : base(errMessage)
        {

        }
    }
}
