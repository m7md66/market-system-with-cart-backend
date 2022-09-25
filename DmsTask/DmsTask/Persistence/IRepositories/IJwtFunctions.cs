using DmsTask.Models;

namespace DmsTask.Persistence.IRepositories
{
    public interface IJwtFunctions
    {
        public Task<string> GenerateJSONWebToken(AppUser user);
    }
}
