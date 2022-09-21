using DmsTask.Models;

namespace DmsTask.Data
{
    public interface IJwtFunctions
    {
        public  Task<string> GenerateJSONWebToken(AppUser user);
    }
}
