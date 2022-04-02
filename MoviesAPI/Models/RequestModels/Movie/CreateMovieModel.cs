using System;
using System.Collections.Generic;

namespace MoviesAPI.Models.RequestModels.Movie
{
    public class CreateMovieModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Poster { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }
        public int UserId { get; set; }

    }
}
