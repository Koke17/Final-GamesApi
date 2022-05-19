using AutoMapper;
using System.Linq;
using VideogamesApi.Dtos;

namespace VideogamesApi.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Videogame, VideogameDto>()
                .ForMember(d => d.DevelopmentStudioIds, opt => opt.MapFrom(dest => dest.DevelopmentStudioVideogame
                .Select(d => d.DevelopmentStudioId)))
                .ForMember(d => d.GenreIds, opt => opt.MapFrom(dest => dest.GenreVideogame
                .Select(d => d.GenreId)))
                .ForMember(d => d.EngineDto, opt => opt.MapFrom(dest => dest.Engine));
                

            CreateMap<Engine, EngineDto>();

            CreateMap<Genre, GenreDto>();

            CreateMap<DevelopmentStudio, DevelopmentStudioDto>();

        }
    }
}
