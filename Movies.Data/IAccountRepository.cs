using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetAsync(string username, string  password);
        Task<ApplicationUser> GetAsync(int id);
        Task<int> CreateAsync(ApplicationUser user);
        Task<List<ApplicationUser>> GetFullUserAsync();
        Task<ApplicationUser> GetFullCertainUserAsync(int userId);
    }
}
