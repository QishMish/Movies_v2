using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.Poco;
using Movies.PersistanceDB.Context;
using Movies.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;


namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesDb Movies { get; set; } = new MoviesDb();
        private ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        IMoviesService _movieService;
        public MoviesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMoviesService movieService)
        {
            _context = context;
            _userManager = userManager;
            _movieService = movieService;   
        }
        public async Task<IActionResult> Index()
        {
        //    var movies = _context.Movie.ToList();
        //    return View(movies);
            var movies = await _movieService.GetAllAsync();
            return View(movies);

        }
        [Authorize]
        public async Task<IActionResult> MovieDetail(int id)
        {
            //var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            //if (movie == null)
            //    return NotFound();
            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;
            var book = new Booking() { User_id = userId, Movie_id = id };
            var purchase = new Purchase() { User_id = userId, Movie_id = id };

            var booked = await _movieService.IsBooked(book);
            var purchased = await _movieService.IsPurchased(purchase);


            ViewData["booked"] = booked;
            ViewData["purchased"] = purchased;

            //return View(movie);
            var movie = await _movieService.GetAsync(id);
            if (movie == null)
                return NotFound();
            

            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> Book(int id)
        {
            var movie = _context.Movie.Where(
            x => x.Id == id).SingleOrDefault();

            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;
           
            var booking = new Booking() { User_id = userId, Movie_id=movie.Id };

            await _context.Booking.AddAsync(booking);
            _context.SaveChanges();
            return RedirectToAction($"MovieDetail", new { id = id });


        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var movie = _context.Movie.Where(
            x => x.Id == id).SingleOrDefault();

            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;

            var booking = new Booking() { User_id = userId, Movie_id = movie.Id };

             _context.Booking.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction($"MovieDetail", new { id = id });



        }
        [HttpPost]
        public async Task<IActionResult> Purchase(int id)
        {
            var movie = _context.Movie.Where(
            x => x.Id == id).SingleOrDefault();

            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;

            var purchase = new Purchase() { User_id = userId, Movie_id = movie.Id };

            await _context.Purchase.AddAsync(purchase);
            _context.SaveChanges();
            return RedirectToAction($"MovieDetail", new { id = id });




        }
        [HttpPost]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var movie = _context.Movie.Where(
            x => x.Id == id).SingleOrDefault();

            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;

            var purchase = new Purchase() { User_id = userId, Movie_id = movie.Id };

            _context.Purchase.Remove(purchase);
            _context.SaveChanges();
            return RedirectToAction($"MovieDetail", new { id = id });
        }
    }
}
