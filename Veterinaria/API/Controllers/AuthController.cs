using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private ITokenService TokenService;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService TokenService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.TokenService = TokenService;
        }

        //Método para login cuando se haga el logout despues de las 3 horas que se establecieron en el jwt 
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            IdentityUser user = await userManager.FindByNameAsync(model.Username);
            LoginModel Usuario = new LoginModel();
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var userRoles = await userManager.GetRolesAsync(user);

                var jwtToken = TokenService.CreateToken(user, userRoles.ToList());

                Usuario.Token = jwtToken;
                Usuario.Roles = userRoles.ToList();
                Usuario.Username = user.UserName;


                return Ok(Usuario);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {

            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
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
            var roles = await roleManager.RoleExistsAsync("User");
            if (!roles)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            await userManager.AddToRoleAsync(user, "User");

            return Ok(new Response { Status = "Success", Message = "Usuario Creado Exitosamente" });

        }

    }
}
