using AutoMapper;
using Movies.Application.Common.Commands.Movies;
using Movies.Application.Dto.Movies;
using Movies.Domain.Entities;

namespace Movies.Application.Mapping;

public class MoviesMappingProfile : Profile
{

    public MoviesMappingProfile()
    {
        
        CreateMap<CreateMovieDto, CreateMovieCommand>()
            .ForMember(cmd => cmd.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<UpdateMovieDto, UpdateMovieCommand>();

        // CreateMap<NovieEntity, GetMovieDto>()
        // .ConstructUsing(src => new GetMovieDto(src.id, src.title, src.release_year, 
            // src.country, src.budget, src.score, src.director_id, null));
        
        // CreateMap<CreateDirectorDto, CreateDirectorCommand>()
        // .ForMember(cmd => cmd.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        // CreateMap<UpdateDirectorDto, UpdateDirectorCommand>();

        // CreateMap<DirectorEntity, GetDirectorDto>()
        // .ConstructUsing(src => new GetDirectorDto(src.id, src.first_name, src.last_name, src.birth_day));
    }
}