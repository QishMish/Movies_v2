using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesAdmin.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RoleManagerController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
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
    }
}