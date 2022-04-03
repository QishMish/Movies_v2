using Movies.Data;
using Movies.Domain.Poco;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies.EF.Repository
{
    public class AccountRepository :IAccountRepository
    {
        private IBaseRepository<ApplicationUser> _repository;
        public AccountRepository(IBaseRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(ApplicationUser user)
        {
            await _repository.AddAsync(user);
            return user.Id;
        }

        public async Task<ApplicationUser> GetAsync(string username, string password)
        {
            return await _repository.GetAsync(username, password);
        }
        public async Task<ApplicationUser> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
        public async Task<List<ApplicationUser>> GetFullUserAsync()
        {
            return await _repository.Table.Include(x => x.Booking).ThenInclude(y=>y.Movie).ToListAsync();
        }
        public async Task<ApplicationUser> GetFullCertainUserAsync(int userId)
        {
            var userWithBookings = _repository.Table.Include(x => x.Booking).ToList().FirstOrDefault(x=>x.Id == userId);
            return /*await _repository.GetAsync(userId);*/ userWithBookings;
        }
    }
}
