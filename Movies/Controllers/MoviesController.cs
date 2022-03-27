using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesDb Movies { get; set; } = new MoviesDb();
        public async Task<IActionResult> Index()
        {
            var movies = Movies.Movies;
            return View(movies);
        }
        public async Task<IActionResult> MovieDetail(int id)
        {
            var movies = Movies.Movies;
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}
