using Azure.Identity;
using BloggingDomain.Interfaces;
using BloggingDomain.Models;
using BloggingInfrastructure.Interfaces;
using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDomain.Services.DbServices
{
    public class DatabaseApiWrapper : IDatabaseApiWrapper
    {
        private readonly IUserRespository _userRepository;
        public DatabaseApiWrapper(IUserRespository userRespository)
        {
            _userRepository = userRespository;
        }

        public bool RegisterUser(User user)
        {
            UserTable infraUser = new UserTable() {Username = user.Username, PasswordHash = user.PasswordHash, PasswordSalt = user.PasswordSalt };
            return _userRepository.Register(infraUser);
        }

        public bool CheckIfUsernameIsTaken(string username)
        {
            return _userRepository.IsUsernameTaken(username);
        }

        public UserTable GetUser(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}
