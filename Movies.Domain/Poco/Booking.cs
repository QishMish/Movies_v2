using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Domain.Poco
{
    public class Booking
    {
        //public int BookingId { get; set; }
        ////public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        public int User_id { get; set; }
        public int Movie_id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Movie Movie { get; set; }
    }
}
