using BloggingDomain.Models;
using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDomain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}
