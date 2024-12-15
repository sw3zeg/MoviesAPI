using AutoMapper;
using Movies.Application.Common.Commands.Directors;
using Movies.Application.Common.Commands.Genres;
using Movies.Application.Dto.Directors;
using Movies.Application.Dto.genres;
using Movies.Domain.Entities;

namespace Movies.Application.Mapping;

public class GenresMappingProfile : Profile 
{
    public GenresMappingProfile()
    {
        CreateMap<CreateGenreDto, CreateGenreCommand>()
            .ForMember(cmd => cmd.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        
        CreateMap<UpdateGenreDto, UpdateGenreCommand>();
        
        CreateMap<GenreEntity, GetGenreDto>();
    }
}