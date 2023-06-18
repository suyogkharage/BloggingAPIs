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
        private readonly ITokenService _tokenService;
        public AuthController(IConfiguration configuration, IPasswordHashService passwordHashService, IDatabaseApiWrapper databaseApiWrapper, ITokenService tokenService)
        {
            _configuration = configuration;
            _passwordHashService = passwordHashService;
            _databaseApiWrapper = databaseApiWrapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public ActionResult Register(UserDTO request)
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

            if (!_databaseApiWrapper.CheckIfUsernameIsTaken(user.Username))
            {
                if (_databaseApiWrapper.RegisterUser(user))
                    return Ok(user);
                else return StatusCode(500, "An error occurred during user registration.");
            }
            else
                return Conflict("The username is already taken.");      
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDTO request)
        {
            //get the user from db using username
            var userDetails = _databaseApiWrapper.GetUser(request.Username);
            
            // if username from db does not match with input username, User not found
            if(userDetails?.Username != request.Username)
            {
                return BadRequest("User not found");
            }
            // verify password hash. If it matches then create token otherwise Wrong password
            if(!_passwordHashService.VerifyPasswordHash(request.Password, userDetails.PasswordHash, userDetails.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            var token = _tokenService.CreateToken(userDetails.Username);
            // send token back to client

            return Ok(token);
        }
    }
}
