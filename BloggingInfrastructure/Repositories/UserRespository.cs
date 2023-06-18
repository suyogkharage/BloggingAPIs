using BloggingInfrastructure.Data;
using BloggingInfrastructure.Interfaces;
using BloggingInfrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingInfrastructure.Repositories
{
    public class UserRespository : IUserRespository
    {
        private readonly DataContext _dbcontext;

        public UserRespository(DataContext dataContext)
        {
            _dbcontext = dataContext;
        }
        public bool Register(UserTable user)
        {
            try
            {
                _dbcontext.Users.Add(user);
                _dbcontext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                //ToDo: implement logging
                return false;
            }
        }

        public bool IsUsernameTaken(string username)
        {
            // Query the database to check if a user with the same username exists.
            return _dbcontext.Users.Any(u => u.Username == username);
        }

        public UserTable GetUserByUsername(string username)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
