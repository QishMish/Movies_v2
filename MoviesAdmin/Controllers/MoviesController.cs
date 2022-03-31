using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies;
using Movies.Domain.Poco;
using Movies.PersistanceDB.Context;
using Movies.Services.Abstractions;
using MoviesAdmin.Models.Movies;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAdmin.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        IMoviesService _movieService;
        public MoviesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMoviesService movieService)
        {
            _context = context;
            _userManager = userManager;
            _movieService = movieService;
        }
        public MoviesDb Movies { get; set; } = new MoviesDb();
        public async Task<IActionResult> Index()
        {
            ////var movies = Movies.Movies;
            //var movies =  _context.Movie.ToList();
            //return View(movies);
            var movies = await _movieService.GetAllAsync();
            return View(movies);
        }
        public async Task<IActionResult> Details(int id)
        {
            //var movies = Movies.Movies;
            //var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            //if (movie == null)
            //    return NotFound();

            //return View(movie);

            var movie = await _movieService.GetAsync(id);
            if (movie == null)
               return NotFound();

            return View(movie);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMoviesModel addMoviesModel)
        {
            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;
            addMoviesModel.UserId = userId;
            //await _context.Movie.AddAsync(addMoviesModel.Adapt<Movie>());
            //_context.SaveChanges();
            //return RedirectToAction("Index");
            await _movieService.AddAsync(addMoviesModel.Adapt<Movie>());
             return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieEntity = await _movieService.GetAsync(id);
            return View(movieEntity.Adapt<EditMoviesModel>());

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditMoviesModel editMoviesModel)
        {
            //var movie = _context.Movie.Where(
            // x => x.Id == editMoviesModel.Id).SingleOrDefault();
            //if (movie != null)
            //{
            //    _context.Entry(movie).CurrentValues.SetValues(editMoviesModel);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(editMoviesModel);
            await _movieService.UpdateAsync(editMoviesModel.Adapt<Movie>());
            return View(editMoviesModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //var movie = _context.Movie.Where(
            // x => x.Id == id).SingleOrDefault();

            //if (movie != null)
            //{
            //    _context.Remove(movie);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return NotFound($"Employee Not Found with ID : {movie.Id}");
            var movieEntity = await _movieService.GetAsync(id);
            if (movieEntity != null)
            {
                await _movieService.RemoveAsync(movieEntity);
                return RedirectToAction("Index");
            }
            return NotFound($"Employee Not Found with ID : {movieEntity.Id}");
        }
    }
}
