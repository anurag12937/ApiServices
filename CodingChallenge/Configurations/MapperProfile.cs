using AutoMapper;
using CodingChallenge.Core.Models;
using System.Diagnostics.CodeAnalysis;

namespace CodingChallenge.Configurations
{
    [ExcludeFromCodeCoverage]
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<StoryDetail, StoryDetailDto>().ReverseMap();
        }
    }
}
