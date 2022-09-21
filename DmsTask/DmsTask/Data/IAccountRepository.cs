using DmsTask.Models;
using identityWithChristina.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DmsTask.Data
{
    public interface IAccountRepository
    {

        public AppUser AddRegistration(RegisterAccountViewModel addRegister);
        public IdentityRole AddRole(string role);
        public List<Items> GetItems();
        public Task<string> userLogin(AppUser user, LoginViewModel newLogging);
    }


    
}
