using AutoMapper;
using BloggingAPI.DTOs;
using BloggingDomain.Models;

namespace BloggingAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPostDTO, BlogPost>();
            // Add more mappings if needed
        }
    }
}
