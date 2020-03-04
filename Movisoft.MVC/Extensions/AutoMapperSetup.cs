using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Movisoft.Aplication.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movisoft.MVC.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Registering Mappings automatically only works if the 
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
    }
}
