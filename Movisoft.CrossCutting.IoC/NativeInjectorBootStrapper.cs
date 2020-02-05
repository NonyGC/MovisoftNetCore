using Microsoft.Extensions.DependencyInjection;
using Movisoft.Aplication.Interface;
using Movisoft.Aplication.Service;
using Movisoft.CrossCutting.Identity.Models;
using Movisoft.Domain.Interfaces;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Domain.Interfaces.UoW;
using Movisoft.Infra.Data.Context;
using Movisoft.Infra.Data.Helper;
using Movisoft.Infra.Data.Repository.Dapper;
using Movisoft.Infra.Data.UoW;
using System;

namespace Movisoft.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency


            // Domain Bus (Mediator)


            // ASP.NET Authorization Polices


            // Application
            services.AddScoped<ISeequipoAppService, SeequipoAppService>();
            services.AddScoped<ISetipequipoAppService, SetipequipoAppService>();

            // Domain - Events

            // Domain - Commands

            // Infra - Data
            services.AddScoped<MovisoftContext>();
            services.AddScoped<IUnitOfWorkDapper, UnitOfWorkDapper>();

            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));

            services.AddScoped<ISeequipoRepository, SeequipoRepository>();
            services.AddScoped<ISetipequipoRepository, SetipequipoRepository>();
            services.AddScoped<ISetopologiaRepository, SetopologiaRepository>();
            services.AddScoped<ISiempresaRepository, SiempresaRepository>();

            services.AddScoped<SeequipoHelper>();

            // Infra - Data EventSourcing

            // Infra - Identity Services

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
