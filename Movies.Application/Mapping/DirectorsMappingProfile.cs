using AutoMapper;
using Movies.Application.Common.Commands.Directors;
using Movies.Application.Dto.Directors;
using Movies.Domain.Entities;

namespace Movies.Application.Mapping;

public class DirectorsMappingProfile : Profile
{
    public DirectorsMappingProfile()
    {
        CreateMap<CreateDirectorDto, CreateDirectorCommand>()
            .ForMember(cmd => cmd.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        
        CreateMap<UpdateDirectorDto, UpdateDirectorCommand>();
        
         CreateMap<DirectorEntity, GetDirectorDto>()
             .ConstructUsing(src => new GetDirectorDto(src.id, src.first_name, 
                 src.last_name, src.birth_day, src.biography, src.photo));
    }
}