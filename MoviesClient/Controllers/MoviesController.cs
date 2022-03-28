using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.Poco;
using Movies.PersistanceDB.Context;
using System.Linq;
using System.Threading.Tasks;


namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesDb Movies { get; set; } = new MoviesDb();
        private ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        public MoviesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var movies = _context.Movie.ToList();
            return View(movies);
        }
        [Authorize]
        public async Task<IActionResult> MovieDetail(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
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
            return RedirectToAction("index");
            
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var movie = _context.Movie.Where(
            x => x.Id == id).SingleOrDefault();

            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;

            var booking = new Booking() { User_id = userId, Movie_id = movie.Id };

            await _context.Booking.AddAsync(booking);
            _context.SaveChanges();
            return RedirectToAction("index");

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
            return RedirectToAction("index");

        }
        [HttpPost]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var movie = _context.Movie.Where(
            x => x.Id == id).SingleOrDefault();

            var user = HttpContext.User.Identity.Name;
            var userId = _context.ApplicationUser.ToList().Find(u => u.UserName == user).Id;

            var booking = new Booking() { User_id = userId, Movie_id = movie.Id };

            await _context.Booking.AddAsync(booking);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
