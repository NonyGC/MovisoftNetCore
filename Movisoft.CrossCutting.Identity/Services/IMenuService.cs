using Movisoft.CrossCutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Movisoft.CrossCutting.Identity.Services
{
    public interface IMenuService
    {
        List<Menu> ObtenerListaMenuPorUsuario(ClaimsPrincipal user);
        string ObtenerRolesPorUsuario(ClaimsPrincipal user);
        string ObtenerMenuHtml(ClaimsPrincipal user);
    }
}
