using AutoMapper;
using VideogamesApi.Dtos;

namespace VideogamesApi.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Videogame, VideogameDto>()
                .ForMember(d => d.DevelopmentStudios, opt => opt.Ignore())
                .ForMember(d => d.EngineDto, opt => opt.MapFrom(dest => dest.Engine))
                .ForMember(d => d.Genres, opt => opt.Ignore());

            CreateMap<Engine, EngineDto>();

            CreateMap<Genre, GenreDto>();

            CreateMap<DevelopmentStudio, DevelopmentStudioDto>();

        }
    }
}
