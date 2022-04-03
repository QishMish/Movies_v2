using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Domain.Poco
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Poster { get; set; }  
        public string Duration { get; set; }
        public int UserId { get; set; }
        public bool Published { get; set; }
        public DateTime StartDate { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public ICollection<Purchase> Purchase { get; set; }

    }
}
