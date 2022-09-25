
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DmsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
     
        public RoleController(RoleManager<IdentityRole> _roleManager )
        {
            roleManager = _roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string role)
        {
            if (role != null)
            {
                IdentityRole newRole = new IdentityRole();
                newRole.Name = role;
                IdentityResult result = await roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return Ok(role);
                }
                else
                {
                    return Problem("error result");
                }
            }
          return Problem("error null value");
        }
    }
}
