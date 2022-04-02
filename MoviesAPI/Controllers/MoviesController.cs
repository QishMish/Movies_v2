using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.Poco;
using Movies.Services.Abstractions;
using MoviesAPI.Models.RequestModels.Movie;
using MoviesClient.Models.UserActions;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        public MoviesController(IMoviesService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }
        [HttpGet]
        [Route("{movieId}")]
        public async Task<IActionResult> GetCertainMovie(int movieId)
        {
            var movie = await _movieService.GetAsync(movieId);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMovie(CreateMovieModel createMovieModel)
        {
          
            await _movieService.AddAsync(createMovieModel.Adapt<Movie>());
            return Ok($"Created");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieModel updateMovieModel)
        {
            await _movieService.UpdateAsync(updateMovieModel.Adapt<Movie>());
            return Ok($"Edited");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieEntity = await _movieService.GetAsync(id);
            if (movieEntity != null)
            {
                await _movieService.RemoveAsync(movieEntity);
                return Ok($"Deleted movie with id:{id}");
            }
            return NotFound($"Movie Not Found with ID : {id}");
        }
        [HttpPost]
        [Route("Book")]
        public async Task<IActionResult> BookMovie(UserActionModel UserActionModel)
        {
            var adaptedBooking = UserActionModel.Adapt<Booking>();
            await _movieService.Book(adaptedBooking);
            return Ok($" {UserActionModel.MovieId} Purchased by user with id:{UserActionModel.UserId}");
        }
        [HttpPost]
        [Route("Purchase")]
        public async Task<IActionResult> PurchaseMovie(UserActionModel UserActionModel)
        {
            var adaptedPurchase = UserActionModel.Adapt<Purchase>();
            await _movieService.Purchase(adaptedPurchase);
            return Ok($" {UserActionModel.MovieId} Purchased by user with id:{UserActionModel.UserId}");
        }
        [HttpDelete]
        [Route("Booking")]
        public async Task<IActionResult> DeleteBooking(UserActionModel UserActionModel)
        {
            var adaptedBooking = UserActionModel.Adapt<Booking>();
            await _movieService.DeleteBooking(adaptedBooking);
            return Ok($"Deleted booking");
        }
        [HttpDelete]
        [Route("Purchase")]
        public async Task<IActionResult> DeletePurchase(UserActionModel UserActionModel)
        {
            var adaptedPurchase = UserActionModel.Adapt<Purchase>();
            await _movieService.DeletePurchase(adaptedPurchase);
            return Ok($"Deleted pruchase");

        }
    }
}
