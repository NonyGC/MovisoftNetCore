using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Aplication.Service;
using Movisoft.Aplication.Service.Entity;
using Movisoft.Aplication.Validations;
using Movisoft.CrossCutting.Identity.Models;
using Movisoft.CrossCutting.Identity.Services;
using Movisoft.Domain.Interfaces;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Domain.Interfaces.Service;
using Movisoft.Domain.Interfaces.UoW;
using Movisoft.Domain.Services;
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

            #region 3 - Aplicacion

            // Application
            services.AddScoped<ISharedAppService, SharedAppService>();
            services.AddScoped<ISeequipoAppService, SeequipoAppService>();
            services.AddScoped<ISetipequipoAppService, SetipequipoAppService>();
            services.AddScoped<ISetopologiaAppService, SetopologiaAppService>();

            //Validacion
            services.AddScoped<SeequipoValidadorInsertar>();
            services.AddScoped<SeequipoValidadorActualizar>();

            services.AddScoped<SetipequipoValidadorActualizar>();
            services.AddScoped<SetipequipoValidadorInsertar>();

            services.AddScoped<SetopologiaValidadorInsertar>();
            services.AddScoped<SetopologiaValidadorActualizar>();

            #endregion

            #region 4 - Dominio

            // Domain - Events

            // Domain

            services.AddScoped<ISeequipoService, SeequipoService>();



            #endregion

            #region 5 - Infraestructura

            // Infra - Data
            services.AddScoped<MovisoftContext>();
            services.AddScoped<IUnitOfWorkDapper, UnitOfWorkDapper>();

            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));

            services.AddScoped<ISeequipoRepository, SeequipoRepository>();
            services.AddScoped<ISetipequipoRepository, SetipequipoRepository>();
            services.AddScoped<ISetopologiaRepository, SetopologiaRepository>();
            services.AddScoped<ISiempresaRepository, SiempresaRepository>();

            services.AddScoped<SeequipoHelper>();
            services.AddScoped<SiempresaHelper>();

            // Infra - Data EventSourcing

            // Infra - Identity Services

            // Infra - Identity
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<ApplicationRole>>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IMenuService, MenuService>();

            #endregion
        }
    }
}
