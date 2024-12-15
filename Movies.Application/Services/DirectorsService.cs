using AutoMapper;
using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Commands.Directors;
using Movies.Application.Common.Queries.Genres;
using Movies.Application.Dto.Directors;

namespace Movies.Application.Services;

public class DirectorsService : IDirectorsService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DirectorsService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    public async Task<Guid> Create(CreateDirectorDto director)
    {
        var command = _mapper.Map<CreateDirectorCommand>(director);
        var id = await _mediator.Send(command);
        return id;
    }

    public async Task<Int64> CreateMany(ICollection<CreateDirectorDto> directors)
    {

        foreach (var director in directors)
            await Create(director);

        return directors.Count;
    }

    public async Task Update(UpdateDirectorDto director)
    {
        var command = _mapper.Map<UpdateDirectorCommand>(director);
        await _mediator.Send(command);
    }

    public async Task Delete(Guid id)
    {
        var command = new DeleteDirectorCommand(id);

        await _mediator.Send(command);
    }

    public async Task<ICollection<GetDirectorDto>> Query(String query, 
        Int64 limit, Int64 offset)
    {
        var response = await _mediator.Send(new GetDirectorsQuery(query, limit, offset));

        var result = _mapper.Map<ICollection<GetDirectorDto>>(response);
        
        return result;
    }
}