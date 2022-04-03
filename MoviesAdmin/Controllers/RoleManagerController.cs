using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.PersistanceDB.Context;

namespace MoviesAdmin.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ApplicationDbContext _context;
        public RoleManagerController(RoleManager<IdentityRole<int>> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var movie = _context.Roles.Where(
            x => x.Id == Id).SingleOrDefault();

            if (movie != null)
            {
                _context.Remove(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound($"Role Not Found with ID : {Id}");
        }
    }
}