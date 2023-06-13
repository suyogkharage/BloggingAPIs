using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BloggingInfrastructure.Data
{
    public static class DataContextConfiguration
    {
        public static void ConfigureDataContext(IServiceCollection services, IConfiguration configuration)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");

            var conf = new ConfigurationBuilder()
                                .AddJsonFile(appSettingsPath)
                                .Build();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(conf.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
