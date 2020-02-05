using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movisoft.CrossCutting.Identity.Data;
using Movisoft.CrossCutting.Identity.Models;

[assembly: HostingStartup(typeof(Movisoft.MVC.Areas.Identity.IdentityHostingStartup))]
namespace Movisoft.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}