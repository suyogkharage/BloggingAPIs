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
        private IConfiguration _configuration;
        public string Register(InfraUser user)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            //var parentDirectory = Directory.GetParent(currentDirectory)?.Parent?.FullName;
            var appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");

            var conf = new ConfigurationBuilder()
                                .AddJsonFile(appSettingsPath)
                                .Build();

            return conf.GetConnectionString("DefaultConnection");

        }
    }
}
