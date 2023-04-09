using AutoMapper;
using BloggersMastersAPI.Models.DTOs.Post;
using BloggersMastersAPI.Models.Models;

namespace BloggersMastersAPI.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostCreateDto>()
                .ReverseMap()
                .ForMember(post => post.Agrees, opt => opt.MapFrom(post => 0))
                .ForMember(post => post.Disagrees, opt => opt.MapFrom(post => 0))
                .ForMember(post => post.CreatedAt, opt => opt.MapFrom(post => DateTime.Now));
            CreateMap<Post, PostModifyDto>()
                .ReverseMap()
                .ForMember(post => post.ModifiedAt, opt => opt.MapFrom(post => DateTime.Now));
        }
    }
}
