using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movisoft.CrossCutting.Identity.Data;
using Movisoft.CrossCutting.Identity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Movisoft.CrossCutting.Identity.Services
{
    public class MenuService: IMenuService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public MenuService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public List<Menu> ObtenerListaMenuPorUsuario(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);

            var lstUserRoles = _dbContext.UserRoles
                .Where(x => x.UserId == int.Parse(userId))
                .Select(x => x.RoleId);

            var listaMenuMenuRol = _dbContext.Menu
                .Join(_dbContext.MenuRol, menu => menu.Id, menuRol => menuRol.MenuId, (m, mr) => new { Menu = m, MenuRol = mr })
                .Where(x => lstUserRoles.Contains(x.MenuRol.RoleId));

            return listaMenuMenuRol.Select(x => x.Menu).ToList();
        }

        public string ObtenerRolesPorUsuario(ClaimsPrincipal user)
        {
            var applicationUser = _userManager.GetUserAsync(user).Result;
            return string.Join(",", _userManager.GetRolesAsync(applicationUser).Result);
        }

        public string ObtenerMenuHtml(ClaimsPrincipal user)
        {
            StringBuilder sb = new StringBuilder();
            var lstMenu = ObtenerListaMenuPorUsuario(user);

            foreach (var menu in lstMenu.Where(x => !x.ParentId.HasValue))
            {
                var lstSegundoNivel = lstMenu.Where(x => x.ParentId == menu.Id).ToList();
                var arrow = lstSegundoNivel.Any() ? "<span class='fa arrow'></span>" : string.Empty;

                sb.Append("<li>");
                sb.Append(MenuLink(menu));

                if (lstSegundoNivel.Any())
                {
                    sb.Append("<ul class='nav nav-second-level'>");

                    foreach (var menu2 in lstSegundoNivel)
                    {
                        var lstTercerNivel = lstMenu.Where(x => x.ParentId == menu2.Id).ToList();

                        sb.Append("<li>");
                        sb.Append(MenuLink(menu2));

                        if (lstTercerNivel.Any())
                        {
                            sb.AppendFormat("<ul class='nav nav-third-level'>");
                            foreach (var menu3 in lstTercerNivel)
                            {
                                sb.Append("<li>");
                                sb.Append(MenuLink(menu3));
                                sb.Append("</li>");
                            }

                            sb.Append("</ul>");
                        }

                        sb.Append("</li>");
                    }

                    sb.Append("</ul>");
                }

                sb.Append("</li>");
            }


            return sb.ToString();
        }

        public string MenuLink(Menu menu, string arrow = "")
        {
            return $"<a href='{menu.AreaName}/{menu.ControllerName}/{menu.ActionName}'><i class='{menu.IconName}'></i> <span class='nav-label'>{menu.Name}</span></a> {arrow}";
        }



    }
}
