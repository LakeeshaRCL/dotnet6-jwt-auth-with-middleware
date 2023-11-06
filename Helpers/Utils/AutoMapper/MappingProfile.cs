using AutoMapper;
using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.Models;

namespace JwtAuthenticationWithMiddlewares.Helpers.Utils.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<StoryModel, StoryDTO>()
                .ForMember(res => res.id, opt => opt.MapFrom(src => src.id))
                .ForMember(res => res.user_id, opt => opt.MapFrom(src => src.user_id))
                .ForMember(res => res.title, opt => opt.MapFrom(src => src.title))
                .ForMember(res => res.description, opt => opt.MapFrom(src => src.description));
        }
    }
}
