using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Abstractions;
using Movies.Services.Models;
using MoviesAPI.Models;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;

        }
        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register(CreateAccountModel req)
        //{
        //    var result = await _service.Register(req.Adapt<UserServiceRegisterModel>());

        //    return Ok(result);
        //}
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel loginModel)
        {
            var token = await _service.Login(loginModel.Adapt<UserServiceLoginModel>());

            return Ok(token);
        }
        [HttpGet]
        [Route("UserWithBokings")]
        public async Task<IActionResult> AllUsersWithBokings()
        {
            var users = await _service.GetFullUserAsync();

            return Ok(users);
        }
        [HttpGet]
        [Route("UserWithBokings/{userId}")]
        public async Task<IActionResult> userWithBookings(int userId)
        {
            var userWithBooking = await _service.GetFullCertainUserAsync(userId);

            return Ok(userWithBooking);
        }
    }
}
