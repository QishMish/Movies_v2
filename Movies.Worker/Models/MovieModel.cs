using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Worker.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Poster { get; set; }
        public string Duration { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
