using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movisoft.CrossCutting.Identity.DTO;
using Movisoft.CrossCutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Movisoft.CrossCutting.Identity.Services
{
    public class IdentityManagerService : IIdentityManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly Dictionary<string, string> _claimTypes;
        public IdentityManagerService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            var fldInfo = typeof(ClaimTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
            _claimTypes = fldInfo.ToDictionary(i => i.Name, i => (string)i.GetValue(null));

        }

        public async Task<IdentityResult> CreateUserAsync(UserDTO userDTO)
        {
            var result = await _userManager.CreateAsync(userDTO, userDTO.Password);
            if (result.Succeeded)
            {
                if (userDTO.ClaimValue != null)
                    await _userManager.AddClaimAsync(userDTO, new Claim(ClaimTypes.Name, userDTO.ClaimValue));
            }

            return result;
        }

        public async Task<ApplicationUser> GetUserById(int id)
        {
            return await _userManager.Users.FirstAsync(x => x.Id == id);
        }

        public IEnumerable<string> GetClaimTypes()
        {
            return _claimTypes.Keys.OrderBy(s => s);
        }

        public Dictionary<int, string> GetRoles()
        {
            return _roleManager.Roles.ToDictionary(r => r.Id, r => r.Name);
        }

        public DatatablesDTO GetUsers(string search, string order, string column, int start, int length)
        {
            var lstUsers = _userManager.Users.Include(u => u.UserRoles).Include(u => u.Claims);

            var qry = lstUsers
                .Where(u => 
                (string.IsNullOrWhiteSpace(search) || u.Email.Contains(search)) || 
                (string.IsNullOrWhiteSpace(search) || u.UserName.Contains(search)));

            if (order == "asc")
                qry = qry.OrderBy(x => EF.Property<string>(x, Char.ToUpper(column[0]) + column.Substring(1)));
            else
                qry = qry.OrderByDescending(x => EF.Property<string>(x, Char.ToUpper(column[0]) + column.Substring(1)));

            var roles = GetRoles();

            return new DatatablesDTO() {
                draw = 1,
                recordsTotal = lstUsers.Count(),
                recordsFiltered = qry.Count(),
                data = qry.Skip(start).Take(length).ToArray().Select(u => new {
                    Id = u.Id,
                    Email = u.Email,
                    LockedOut = u.LockoutEnd == null ? string.Empty : "SI",
                    Roles = u.UserRoles.Select(r => roles[r.RoleId]),
                    Claims = u.Claims.Select(c => new KeyValuePair<string, string>(_claimTypes.Single(x => x.Value == c.ClaimType).Key, c.ClaimValue)),
                    DisplayName = u.Claims.FirstOrDefault(c => c.ClaimType == ClaimTypes.Name)?.ClaimValue,
                    UserName = u.UserName
                })
            };
        }

        public async Task<IdentityResult> UpdateUserAsync(UserDTO userDTO)
        {
            var user = await GetUserById(userDTO.Id);
            if (user == null)
                return null;

            user.Email = userDTO.Email;
            user.LockoutEnd = userDTO.Locked ? DateTimeOffset.MaxValue : default(DateTimeOffset?);

            return await _userManager.UpdateAsync(user);
        }

        public async Task UpdateUserRolesAsync(int id, string[] roles)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (string role in roles.Except(userRoles))
                    await _userManager.AddToRoleAsync(user, role);

                foreach (string role in userRoles.Except(roles))
                    await _userManager.RemoveFromRoleAsync(user, role);
            }
        }

        public async Task UpdateUserClaimsAsync(int id, List<KeyValuePair<string, string>> claims)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);

                foreach (var kvp in claims.Where(a => !userClaims.Any(b => _claimTypes[a.Key] == b.Type && a.Value == b.Value)))
                    await _userManager.AddClaimAsync(user, new Claim(_claimTypes[kvp.Key], kvp.Value));

                foreach (var claim in userClaims.Where(a => !claims.Any(b => a.Type == _claimTypes[b.Key] && a.Value == b.Value)))
                    await _userManager.RemoveClaimAsync(user, claim);
            }           
        }

        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> UpdateUserPasswordAsync(ApplicationUser user, string password)
        {
            if (await _userManager.HasPasswordAsync(user))
                await _userManager.RemovePasswordAsync(user);

            return await _userManager.AddPasswordAsync(user, password);
        }

        public DatatablesDTO GetRoles(string searchValue, string ordering, string column, int start, int length)
        {

            var roles = _roleManager.Roles.Include(r => r.RoleClaims);

            var qry = roles.Where(r =>
                (string.IsNullOrWhiteSpace(searchValue) || r.Name.Contains(searchValue))
            );

            if (ordering == "asc")
                qry = qry.OrderBy(x => EF.Property<string>(x, Char.ToUpper(column[0]) + column.Substring(1)));
            else
                qry = qry.OrderByDescending(x => EF.Property<string>(x, Char.ToUpper(column[0]) + column.Substring(1)));

            var result = new DatatablesDTO
            {
                recordsTotal = roles.Count(),
                recordsFiltered = qry.Count(),
                data = qry.Skip(start).Take(length).ToArray().Select(r => new {
                    Id = r.Id,
                    Name = r.Name,
                    Claims = r.RoleClaims.Select(c => new KeyValuePair<string, string>(_claimTypes.Single(x => x.Value == c.ClaimType).Key, c.ClaimValue))
                })
            };

            return result;
        }

        public async Task<IdentityResult> CreateRoleAsync(string name)
        {
            var role = new ApplicationRole(name);

            return await _roleManager.CreateAsync(role);
        }

        public async Task<ApplicationRole> GetRoleById(int id)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IdentityResult> UpdateRoleAsync(ApplicationRole role)
        {
            return await _roleManager.UpdateAsync(role);
        }

        public async Task UpdateRoleClaims(ApplicationRole role, List<KeyValuePair<string, string>> claims)
        {
            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var kvp in claims.Where(a => !roleClaims.Any(b => _claimTypes[a.Key] == b.Type && a.Value == b.Value)))
                await _roleManager.AddClaimAsync(role, new Claim(_claimTypes[kvp.Key], kvp.Value));

            foreach (var claim in roleClaims.Where(a => !claims.Any(b => a.Type == _claimTypes[b.Key] && a.Value == b.Value)))
                await _roleManager.RemoveClaimAsync(role, claim);
        }

        public async Task<IdentityResult> DeleteRoleAsync(ApplicationRole role)
        {
            return await _roleManager.DeleteAsync(role);
        }
    }
}
