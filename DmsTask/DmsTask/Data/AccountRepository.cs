using DmsTask.Models;
using identityWithChristina.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly  DmsContext _context;
        private readonly IJwtFunctions _jwtFunctions;
        public AccountRepository(
            DmsContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IJwtFunctions jwtFunctions
            )
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
         
            _jwtFunctions = jwtFunctions;
        }


        public AppUser AddRegistration(RegisterAccountViewModel addRegister)
        {
            AppUser appUser = new AppUser();
            appUser.Email = addRegister.Email;
            appUser.UserName = addRegister.UserName;
            appUser.CustomerDescription = addRegister.CustomerDescription;
            appUser.CustomerDescriptionAr = addRegister.CustomerDescriptionAr;

            return appUser;
        }
        public async Task <string> userLogin(AppUser user, LoginViewModel newLogging)
        {
            //Microsoft.AspNetCore.Identity.SignInResult signInResult =
            //     await signInManager.PasswordSignInAsync(user, newLogging.Password, newLogging.IsPresist, false);
            bool checkPassword = await userManager.CheckPasswordAsync(user, newLogging.Password);
            if (checkPassword) {
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
            IdentityRole newRole = new IdentityRole();
            newRole.Name = role;
            return newRole;
        }
        public List<Items> GetItems()
        {
            return _context.Items.ToList();
        }



    }
}
