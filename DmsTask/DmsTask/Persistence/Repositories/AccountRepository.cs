using AutoMapper;
using DmsTask.Models;
using DmsTask.Persistence.IRepositories;
using DmsTask.Resource.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly DmsContext _context;
        private readonly IJwtFunctions _jwtFunctions;
        private readonly IMapper mapper;

        public AccountRepository(
            DmsContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IJwtFunctions jwtFunctions,
            IMapper mapper
            )
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;

            _jwtFunctions = jwtFunctions;
            this.mapper = mapper;
        }


        public async Task<AppUser> AddRegistration(RegisterDto addRegister)
        {
          
            var user =  mapper.Map<AppUser>(addRegister);

       await userManager.CreateAsync(user, addRegister.password);
            //await userManager.AddToRoleAsync(user, "customer");
            return user;
        }
        public async Task<string> userLogin(AppUser user, LoginDto newLogging)
        {
            //Microsoft.AspNetCore.Identity.SignInResult signInResult =
            //     await signInManager.PasswordSignInAsync(user, newLogging.Password, newLogging.IsPresist, false);
            bool checkPassword = await userManager.CheckPasswordAsync(user, newLogging.Password);
            if (checkPassword)
            {
                var token = await _jwtFunctions.GenerateJSONWebToken(user);
                return token;
            }

            //Microsoft.AspNetCore.Identity.SignInResult signInResult =
            //          await signInManager.PasswordSignInAsync(user, newLogging.Password, newLogging.IsPresist, false);
            //if (signInResult.Succeeded)
            //{
            //var UserRole = await userManager.GetRolesAsync(user);
            //return Ok(new {Customer_id=user.Id,role=UserRole});

            //}
            else return "error";

        }

        public IdentityRole AddRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {

                IdentityRole newRole = new IdentityRole();
                newRole.Name = role;
                return newRole;
            }
            return null;
        }
        public List<Items> GetItems()
        {
            return _context.Items.ToList();
        }



    }
}
