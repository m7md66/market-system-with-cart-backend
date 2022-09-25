using DmsTask.Models;
using DmsTask.Resource.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DmsTask.Persistence.IRepositories
{
    public interface IAccountRepository
    {

        public Task <AppUser> AddRegistration(RegisterDto addRegister);
        public IdentityRole AddRole(string role);
        public List<Items> GetItems();
        public Task<string> userLogin(AppUser user, LoginDto newLogging);
    }



}
