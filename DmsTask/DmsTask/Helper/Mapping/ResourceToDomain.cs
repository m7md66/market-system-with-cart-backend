using AutoMapper;
using DmsTask.Models;
using DmsTask.Resource.Account;

namespace DmsTask.Helper.Mapping
{
    public class ResourceToDomain:Profile
    {
        public ResourceToDomain()
        {
            CreateMap<RegisterDto, AppUser>()
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.password));
        }
    }
}
