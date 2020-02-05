using Microsoft.AspNetCore.Http;
using Movisoft.CrossCutting.Identity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Movisoft.CrossCutting.Identity.Services
{
    public class MenuService
    {
        private readonly IHttpContextAccessor _accessor;
        public MenuService()
        {
        }

        public void GetMenu()
        {

            var roles = ((ClaimsIdentity)_accessor.HttpContext.User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);


        }
    }
}
