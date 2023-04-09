using AutoMapper;
using BloggersMastersAPI.Models.DTOs.User;
using BloggersMastersAPI.Models.Models;

namespace BloggersMastersAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
        }
    }
}
