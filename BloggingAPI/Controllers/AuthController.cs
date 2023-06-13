using BloggingAPI.DTOs;
using BloggingDomain.Interfaces;
using BloggingDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IDatabaseApiWrapper _databaseApiWrapper;
        public AuthController(IConfiguration configuration, IPasswordHashService passwordHashService, IDatabaseApiWrapper databaseApiWrapper)
        {
            _configuration = configuration;
            _passwordHashService = passwordHashService;
            _databaseApiWrapper = databaseApiWrapper;
        }

        [HttpPost("register")]
        public ActionResult<string> Register(UserDTO request)
        {
            //create password hash & salt
            _passwordHashService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // form user to be saved into database
            User user = new User()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            return _databaseApiWrapper.RegisterUser(user);
            



        }
    }
}
