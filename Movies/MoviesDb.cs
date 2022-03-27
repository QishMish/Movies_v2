using Movies.Domain.Poco;
using System;
using System.Collections.Generic;

namespace Movies
{
    public class MoviesDb
    {
      
        public List<Movie> Movies = new List<Movie>
        {
            new Movie
                {
                    Id = 1,
                    Title = "GoldenEye",
                    Genre = "Action",
                    Description = "Years after a friend and fellow 00 agent is killed on a joint mission, a Russian crime syndicate steals a secret space-based weapons program known as 'GoldenEye' and James Bond has to stop them from using it.",
                    Poster = "https://m.media-amazon.com/images/M/MV5BMzk2OTg4MTk1NF5BMl5BanBnXkFtZTcwNjExNTgzNA@@._V1_UX140_CR0,0,140,209_AL_.jpg",
                    Duration = "2h 10m",
                    StartDate = DateTime.Now
                },
                new Movie
                {
                    Id = 2,
                    Title = "Tomorrow Never Dies",
                    Genre ="Adventure",
                    Description = "James Bond sets out to stop a media mogul's plan to induce war between China and the UK in order to obtain exclusive global media coverage",
                    Poster= "https://m.media-amazon.com/images/M/MV5BMTM1MTk2ODQxNV5BMl5BanBnXkFtZTcwOTY5MDg0NA@@._V1_UX140_CR0,0,140,209_AL_.jpg",
                    Duration = "1h 59m",
                    StartDate = DateTime.Now
                },
                new Movie
                {
                    Id = 3,
                    Title = "Abraham Lincoln: Vampire Hunter",
                    Genre =  "Thriller",
                    Description = "Abraham Lincoln, the 16th President of the United States, discovers vampires are planning to take over the United States. He makes it his mission to eliminate them.",
                    Poster = "https://m.media-amazon.com/images/M/MV5BNjY2Mzc0MDA4NV5BMl5BanBnXkFtZTcwOTg5OTcxNw@@._V1_UY209_CR0,0,140,209_AL_.jpg",
                    Duration = "1h 5m",
                    StartDate = DateTime.Now
                },
                new Movie
                {
                    Id = 4,
                    Title = "Enough",
                    Genre = "Crime",
                    Description = "After running away fails, a terrified woman empowers herself in order to battle her abusive husband.",
                    Poster ="https://m.media-amazon.com/images/M/MV5BZTViYzM3MWYtM2IzMC00NjMwLWE2ZDQtMTQ1YmE5NGE0MTU5XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UY209_CR0,0,140,209_AL_.jpg",
                    Duration = "1h 55m",
                    StartDate = DateTime.Now
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Fast and the Furious",
                    Genre ="Thriller" ,
                    Description = "Los Angeles police officer Brian O'Conner must decide where his loyalty really lies when he becomes enamored with the street racing world he has been sent undercover to destroy.",
                    Poster = "https://m.media-amazon.com/images/M/MV5BNzlkNzVjMDMtOTdhZC00MGE1LTkxODctMzFmMjkwZmMxZjFhXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UY209_CR0,0,140,209_AL_.jpg",
                    Duration = "1h 46m",
                    StartDate = DateTime.Now
                }
        };
    }
}
