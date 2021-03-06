using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Poco;
using Movies.PersistanceDB.Context;
using Movies.Services.Abstractions;
using MoviesAdmin.Models;
using MoviesAdmin.Models.UserRolesModels;


namespace MoviesAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly IMoviesService _moviesService;

        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, ApplicationDbContext context, IAccountService accountService, IMoviesService moviesService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _accountService = accountService;
            _moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }

        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        [HttpGet]
        //public async Task<IActionResult> Delete()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Delete(int userId)
        {
            var movie = _context.ApplicationUser.Where(
            x => x.Id == userId).SingleOrDefault();

            if (movie != null)
            {
                _context.Remove(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound($"Employee Not Found with ID : {movie.Id}");
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        [AllowAnonymous]

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UserBookings(int UserId)
        {
            var userWithBookings = await _accountService.GetFullCertainUserAsync(UserId);
            var user = await  _accountService.GetAsync(UserId);
            var movies = userWithBookings.Booking;
            List<Tuple<int, string>> movieDetails = new List<Tuple<int, string>>();

            foreach (var item in movies)
            {
                var mov = await _moviesService.GetAsync(item.Movie_id);
                movieDetails.Add(new Tuple<int, string>(mov.Id, mov.Title));
            }
            ViewData["user"] = userWithBookings.UserName;
            ViewData["movies"] = movieDetails;
            //var movieTitles
            return View(userWithBookings);
        }
        [HttpPost]
        public async Task<IActionResult> CancelBooking(int UserId, int MovieId)
        {
            var booking = new Booking() { User_id = UserId, Movie_id = MovieId };   
            await _moviesService.DeleteBooking(booking);
            return RedirectToAction("Index");
        }
    }
}