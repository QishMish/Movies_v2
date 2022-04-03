using Movies.Data;
using Movies.Domain.Poco;
using Movies.Services.Abstractions;
using Movies.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repo;
        private readonly IJwtService _jwtService;

        public AccountService(IAccountRepository repo, IJwtService jwtService)
        {
            _repo = repo;
            _jwtService = jwtService;
        }
        public async Task<int> Register(ApplicationUser user)
        {
            return await _repo.CreateAsync(user);
        }
        public async Task<string> Login(UserServiceLoginModel user)
        {
            var userEntity = await _repo.GetAsync(user.Username, user.Password);

            if (userEntity == null) throw new Exception();

            return _jwtService.GenerateJwtToken(userEntity.UserName);
        }
        public async Task<ApplicationUser> GetAsync(int id)
        {
            return await _repo.GetAsync(id);
        }
        public async Task<List<ApplicationUser>> GetFullUserAsync()
        {
            return await _repo.GetFullUserAsync();
        }
        public async Task<ApplicationUser> GetFullCertainUserAsync(int userId)
        {
            return await _repo.GetFullCertainUserAsync(userId);
        }

    }
}
