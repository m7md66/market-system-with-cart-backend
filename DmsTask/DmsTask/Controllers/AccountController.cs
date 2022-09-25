using DmsTask.Models;
using DmsTask.Persistence.IRepositories;
using DmsTask.Resource.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DmsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtFunctions _jwtFunctions;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IAccountRepository accountRepository,
            IJwtFunctions jwtFunctions)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _accountRepository = accountRepository;
            _jwtFunctions = jwtFunctions;
        }

        //registration
        [HttpPost]
        public async Task<ActionResult> Registration(RegisterDto newAccount)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _accountRepository.AddRegistration(newAccount);
              
                if (user !=null)
                {
                    return Ok(user);
                 }
                else
                {
                    return Problem("proplem");
                }
            }
            else
                return BadRequest();
        }

        //login
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody]LoginDto newLogging)
        {
                AppUser user = await userManager.FindByNameAsync(newLogging.UserName);
                if (user != null)
                {
                string logResult = await _accountRepository.userLogin(user, newLogging);
                if (!(logResult == "error"))
                  { return Ok(new {token= logResult }); }
                else
                    {
                    return Unauthorized("uncorrect password");
                    }
                }
                else
                {
                    return Unauthorized("uncorrect user name");
                }
        }
        //log out
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Login");
        }

        //Add admin
         [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddAdmin(RegisterDto newAccount, [FromQuery] string role)
        {

            AppUser user =await _accountRepository.AddRegistration(newAccount);
        
            if (user !=null)
            {
                 await userManager.AddToRoleAsync(user, role);
                // await signInManager.SignInAsync(user, false);
                return Created("done", newAccount);
            }
            else
            {
               
             return Problem("proplem");
            }
        }

    
       
    }
}
