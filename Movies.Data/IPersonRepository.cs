using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    internal interface IPersonRepository
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<List<ApplicationUser>> GetAllFullAsync();
        Task<ApplicationUser> GetAsync(int id);
        Task<int> CreateAsync(ApplicationUser user);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
