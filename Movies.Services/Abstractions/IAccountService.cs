using Movies.Domain.Poco;
using Movies.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Abstractions
{
    public interface IAccountService
    {
        Task<int> Register(ApplicationUser user);

        Task<string> Login (UserServiceLoginModel user);
        Task<ApplicationUser> GetAsync(int id);
        Task<List<ApplicationUser>> GetFullUserAsync();
        Task<ApplicationUser> GetFullCertainUserAsync(int userId);

    }
}
