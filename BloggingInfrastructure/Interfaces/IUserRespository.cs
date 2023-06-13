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
        string Register(InfraUser user);
    }
}
