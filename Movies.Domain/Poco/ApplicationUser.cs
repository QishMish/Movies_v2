using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Domain.Poco
{

    public class ApplicationUser : IdentityUser<int> 
    {
        public ICollection<Movie> Movies { get; set; }
        public  ICollection<Booking> Booking { get; set; }
        public  ICollection<Purchase> Purchase { get; set; }
    }
}
