using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models.RequestModels.Movie;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok("All Movies");
        }
        [HttpGet]
        [Route("{movieId}")]
        public async Task<IActionResult> GetCertainMovie(int movieId)
        {
            return Ok($"{movieId} Movie");
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMovie(CreateMovieModel createMovieModel)
        {
            return Ok($"{createMovieModel}");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieModel updateMovieModel)
        {
            return Ok($"{updateMovieModel}");
        }
        [HttpPost]
        [Route("Buy/{movieId}")]
        public async Task<IActionResult> PurchaseMovie(int movieId)
        {
            return Ok($" buy {movieId}");
        }
        [HttpPost]
        [Route("Book/{movieId}")]
        public async Task<IActionResult> BookMovie(int movieId)
        {
            return Ok($" book {movieId}");
        }

    }
}
