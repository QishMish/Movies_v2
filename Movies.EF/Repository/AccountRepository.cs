using Movies.Data;
using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF.Repository
{
    public class AccountRepository :IAccountRepository
    {
        private IBaseRepository<ApplicationUser> _repository;
        public AccountRepository(IBaseRepository<ApplicationUser> repository)
        {

        }
        public Task<int> CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllFullAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
