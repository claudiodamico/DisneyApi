using AutoMapper;
using DisneyApi.Domain.DTOs;
using DisneyApi.Domain.Entities;

namespace DisneyApi.Presentation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personaje, PersonajeDto>();
            CreateMap<PersonajeDtoForCreationOrUpdate, Personaje>();
            CreateMap<Pelicula, PeliculaDto>()
            .ForMember(PeliculaDto => 
                       PeliculaDto.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<Personaje, PersonajeDtoForDetails>();
            CreateMap<PeliculaDtoForCreationOrUpdate, Pelicula>();
            CreateMap<Pelicula, PeliculaDtoForDetails>()
            .ForMember(PeliculaDtoForDetails => 
                       PeliculaDtoForDetails.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion.ToString("yyyy-MM-dd"))); ;
        }
    }
}
