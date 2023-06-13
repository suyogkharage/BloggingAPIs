using BloggingDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDomain.Interfaces
{
    public interface IDatabaseApiWrapper
    {
        string RegisterUser(User user);
    }
}
