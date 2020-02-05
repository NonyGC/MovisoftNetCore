using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Infra.Data.Context
{
    public class MovisoftContext : DbContext
    {
        private readonly IWebHostEnvironment _env;

        public MovisoftContext(IWebHostEnvironment env)
        {
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //get the configuration from the app settings
            var config = new ConfigurationBuilder()
            .SetBasePath(_env.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .Build();

            // define the database to use
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseNpgsql("Server=127.0.0.1;Database=Movisoft100;Username=postgres;Password=Jscript0");
        }
    }
}
