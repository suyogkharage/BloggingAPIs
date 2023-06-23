using BloggingDomain.Models;
using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDomain.Interfaces
{
    public interface IDatabaseApiWrapper
    {
        bool RegisterUser(User user);
        bool CheckIfUsernameIsTaken(string username);
        UserTable GetUser(string username);
        void AddBlogPost(BlogPost blogPost);
    }
}
