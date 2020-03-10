using Microsoft.AspNetCore.Identity;
using Movisoft.CrossCutting.Identity.DTO;
using Movisoft.CrossCutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movisoft.CrossCutting.Identity.Services
{
    public interface IIdentityManagerService
    {
        Dictionary<int, string> GetRoles();
        IEnumerable<string> GetClaimTypes();
        DatatablesDTO GetUsers(string search, string order, string column, int start, int length);
        Task<IdentityResult> CreateUserAsync(UserDTO userDTO);
        Task<ApplicationUser> GetUserById(int id);
        Task<IdentityResult> UpdateUserAsync(UserDTO userDTO);
        Task UpdateUserRolesAsync(int id, string[] roles);
        Task UpdateUserClaimsAsync(int id, List<KeyValuePair<string, string>> claims);
        Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
        Task<IdentityResult> UpdateUserPasswordAsync(ApplicationUser user, string password);
        DatatablesDTO GetRoles(string searchValue, string ordering, string column, int start, int length);
        Task<IdentityResult> CreateRoleAsync(string name);
        Task<ApplicationRole> GetRoleById(int id);
        Task<IdentityResult> UpdateRoleAsync(ApplicationRole role);
        Task UpdateRoleClaims(ApplicationRole role, List<KeyValuePair<string, string>> claims);
        Task<IdentityResult> DeleteRoleAsync(ApplicationRole role);
    }
}
