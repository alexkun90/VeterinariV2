using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UsuarioController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var listaUsuarios = new List<UserModel>();

            foreach (var user in userManager.Users.ToList())
            {
                var roles = await userManager.GetRolesAsync(user);

                listaUsuarios.Add(new UserModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Password = user.PasswordHash, 
                    Roles = roles.ToList()
                });
            }
            return new JsonResult(listaUsuarios);
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            var usuario = await userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Usuario no encontrado!" });
            }

            var roles = await userManager.GetRolesAsync(usuario);

            var result = new
            {
                User = new
                {
                    usuario.Id,
                    usuario.UserName,
                    usuario.Email
                },
                Roles = roles
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {

            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "El usuario ya existe!" });
            }

            IdentityUser user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "INternal server Error" });

            }

            foreach(var role in model.Roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await userManager.AddToRoleAsync(user, role);
                    if (!roleResult.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Error al agregar el rol {role}" });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"El rol {role} no es válido!" });
                }
            }           
            return Ok(new Response { Status = "Success", Message = "Usuario Creado Exitosamente" });

        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserModel model)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new Response { Status = "Error", Message = "Usuario no encontrado." });
            }

            if (user.UserName != model.Username)
            {
                var userWithNewName = await userManager.FindByNameAsync(model.Username);
                if (userWithNewName != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "El nombre de usuario ya existe." });
                }

                user.UserName = model.Username;
            }

            user.Email = model.Email;

            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Error al actualizar la información del usuario." });
            }

            var currentRoles = await userManager.GetRolesAsync(user);

            var rolesToRemove = currentRoles.Except(model.Roles).ToList();
            if (rolesToRemove.Any())
            {
                var removeResult = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
                if (!removeResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Error al eliminar roles del usuario." });
                }
            }
            var rolesToAdd = model.Roles.Except(currentRoles).ToList();
            if (rolesToAdd.Any())
            {
                foreach (var role in rolesToAdd)
                {
                    if (await roleManager.RoleExistsAsync(role))
                    {
                        var addResult = await userManager.AddToRoleAsync(user, role);
                        if (!addResult.Succeeded)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Error al agregar el rol {role}." });
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"El rol {role} no es válido." });
                    }
                }
            }
            return Ok(new Response { Status = "Success", Message = "Usuario actualizado exitosamente." });
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new Response { Status = "Error", Message = "Usuario no encontrado." });
            }

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Error al eliminar el usuario." });
            }

            return Ok(new Response { Status = "Success", Message = "Usuario eliminado exitosamente." });
        }

    }
}

