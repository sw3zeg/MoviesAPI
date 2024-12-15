using System.Transactions;
using AutoMapper;
using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Commands.Genres;
using Movies.Application.Common.Queries.Genres;
using Movies.Application.Dto.genres;
using Movies.Domain.Entities;

namespace Movies.Application.Services;

public class GenresService : IGenresService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GenresService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    public async Task<Guid> Create(CreateGenreDto genre)
    {
        var command = _mapper.Map<CreateGenreCommand>(genre);
        var id = await _mediator.Send(command);
        return id;
    }

    public async Task<Int64> CreateMany(ICollection<CreateGenreDto> genres)
    {
        
        foreach (var genre in genres)
            await Create(genre);
        
        return genres.Count;
    }

    public async Task Update(UpdateGenreDto genre)
    {
        var command = _mapper.Map<UpdateGenreCommand>(genre);
        await _mediator.Send(command);
    }

    public async Task Delete(Guid id)
    {
        var command = new DeleteGenreCommand(id);

        await _mediator.Send(command);
    }

    public async Task<ICollection<GetGenreDto>> Query(String query, 
        Int64 limit, Int64 offset)
    {
        var response = await _mediator.Send(new GetGenresQuery(query, limit, offset));

        var result = _mapper.Map<ICollection<GetGenreDto>>(response);
        
        return result;
    }
}