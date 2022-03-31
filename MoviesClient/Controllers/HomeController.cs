using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Services.Abstractions;
using MoviesClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IMoviesService _movieService;

        public HomeController(ILogger<HomeController> logger, IMoviesService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            //return View();
            var movies = await _movieService.GetAllAsync();
            return View(movies);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
