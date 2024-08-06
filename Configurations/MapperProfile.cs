using AutoMapper;
using CodingChallenge.Core.Models;

namespace CodingChallenge.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StoryDetail, StoryDetailDto>().ReverseMap();
        }
    }
}
