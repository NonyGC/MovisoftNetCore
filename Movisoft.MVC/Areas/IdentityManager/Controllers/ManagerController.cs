using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movisoft.CrossCutting.Identity.DTO;
using Movisoft.CrossCutting.Identity.Services;

namespace Movisoft.MVC.Areas.IdentityManager.Controllers
{
    [Area("IdentityManager")]
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly IIdentityManagerService _identityManagerService;
        public ManagerController(ILogger<ManagerController> logger, IIdentityManagerService identityManagerService)
        {
            _logger = logger;
            _identityManagerService = identityManagerService;
        }

        public IActionResult Users()
        {
            ViewBag.Roles = _identityManagerService.GetRoles();
            ViewBag.ClaimTypes = _identityManagerService.GetClaimTypes();
            return View();
        }

        public IActionResult Roles()
        {
            ViewBag.ClaimTypes = _identityManagerService.GetClaimTypes();
            return View();
        }

        [HttpGet("api/[action]")]
        public IActionResult UserList(int draw, List<Dictionary<string, string>> columns, List<Dictionary<string, string>> order,
            int start, int length, Dictionary<string, string> search)
        {
            string searchValue = search["value"];
            var idx = int.Parse(order[0]["column"]);
            var ordering = order[0]["dir"];
            var column = columns[idx]["data"];

            var dataUsers = _identityManagerService.GetUsers(searchValue, ordering, column, start, length);
            dataUsers.draw = draw;

            return Json(dataUsers);
        }

        [HttpPost("api/[action]")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                var result = await _identityManagerService.CreateUserAsync(userDTO);
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falla al crear usuario {userName}.", userDTO.UserName);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("api/[action]")]
        public async Task<ActionResult> UpdateUser(UserDTO userDTO, string[] roles, List<KeyValuePair<string, string>> claims)
        {
            try
            {
                var result = await _identityManagerService.UpdateUserAsync(userDTO);

                if (result.Succeeded)
                {
                    if(roles.Any())
                        await _identityManagerService.UpdateUserRolesAsync(userDTO.Id, roles);

                    if(claims.Any())
                        await _identityManagerService.UpdateUserClaimsAsync(userDTO.Id, claims);

                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el usuario {userId}.", userDTO.Id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("api/[action]")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _identityManagerService.GetUserById(id);
                if (user == null)
                    return NotFound("Usuario no encontrado.");

                var result = await _identityManagerService.DeleteUserAsync(user);
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario {userId}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("api/[action]")]
        public async Task<IActionResult> ResetPassword(int id, string password, string verify)
        {
            try
            {
                if (password != verify)
                    return BadRequest("Las contraseñas ingresadas no coinciden.");

                var user = await _identityManagerService.GetUserById(id);
                if (user == null)
                    return NotFound("Usuario no encontrado.");

                var result = await _identityManagerService.UpdateUserPasswordAsync(user, password);
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Restablecimiento de contraseña fallida para la usuario {userId}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("api/[action]")]
        public IActionResult RoleList(int draw, List<Dictionary<string, string>> columns, List<Dictionary<string, string>> order, int start, int length, Dictionary<string, string> search)
        {

            string searchValue = search["value"];
            var idx = int.Parse(order[0]["column"]);
            var ordering = order[0]["dir"];
            var column = columns[idx]["data"];

            DatatablesDTO data = _identityManagerService.GetRoles(searchValue, ordering, column, start, length);
            data.draw = draw;

            return Json(data);
        }

        [HttpPost("api/[action]")]
        public async Task<IActionResult> CreateRole(string name)
        {
            try
            {
                var result = await _identityManagerService.CreateRoleAsync(name);
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fallo al crear rol { name}.", name);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("api/[action]")]
        public async Task<ActionResult> UpdateRole(int id, string name, List<KeyValuePair<string, string>> claims)
        {
            try
            {
                var role = await _identityManagerService.GetRoleById(id);
                if (role == null)
                    return NotFound("Rol no encontrado.");

                role.Name = name;

                var result = await _identityManagerService.UpdateRoleAsync(role);
                if (result.Succeeded)
                {
                    await _identityManagerService.UpdateRoleClaims(role, claims);

                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rol de actualización de fallas { roleId}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("api/[action]")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _identityManagerService.GetRoleById(id);
                if (role == null)
                    return NotFound("Rol no encontrado.");

                var result = await _identityManagerService.DeleteRoleAsync(role);
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                    return BadRequest(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fallo al eliminar {roleId}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}