using DmsTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DmsTask.Data
{
    public class JwtFunctions:IJwtFunctions
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DmsContext _DbContext;
        public JwtFunctions(
            DmsContext DbContext,
            UserManager<AppUser> userManager
            )
        {
            _DbContext = DbContext;
            _userManager = userManager;
        }
        public async Task<string> GenerateJSONWebToken(AppUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.
            GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // user info
            var UserRole =string.Join("-", await _userManager.GetRolesAsync(user));
      
            //claims
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", user.Id));
            permClaims.Add(new Claim("name", user.UserName));
            permClaims.Add(new Claim("roles", UserRole));
            //claims
            var token = new JwtSecurityToken( 
                null,
                null,
                 permClaims,
            expires: DateTime.Now.AddMinutes(120),
           
            signingCredentials: credentials
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
