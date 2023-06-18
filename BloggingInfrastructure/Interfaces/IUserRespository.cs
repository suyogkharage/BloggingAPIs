using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingInfrastructure.Interfaces
{
    public interface IUserRespository
    {
        bool Register(UserTable user);
        bool IsUsernameTaken(string username);
        UserTable GetUserByUsername(string username);
    }
}
