using System.Transactions;
using AutoMapper;
using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Commands.Movies;
using Movies.Application.Common.Queries;
using Movies.Application.Common.Queries.Genres;
using Movies.Application.Dto.genres;
using Movies.Application.Dto.Movies;

namespace Movies.Application.Services;

public class MoviesService : IMoviesService
{
    
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MoviesService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    
    
    public async Task Delete(Guid id)
    {
        var command = new DeleteMovieCommand(id);
        
        await _mediator.Send(command);
    }

    public async Task<ICollection<GetMovieDto>> Query(string query, long limit, long offset)
    {
        ICollection<GetMovieDto> movies = new List<GetMovieDto>();
        
        var moviesQuery = new GetMoviesQuery(query, limit, offset);
        
        var moviesResponse = await _mediator.Send(moviesQuery);
        
        foreach (var movie in moviesResponse)
        {
            var genresQuery = new GetMovieGenresQuery(movie.id);
            var genres = await _mediator.Send(genresQuery);
            
            movies.Add(new GetMovieDto(movie, genres));
        }
        
        return movies;
    }

    public async Task<Int64> CreateMany(ICollection<CreateMovieDto> movies)
    {
        
        foreach (var movie in movies)
            await Create(movie);
            
        return movies.Count;
    }

    public async Task Update(UpdateMovieDto movie)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await ClearMovieGenres(movie.Id);
            
            var command = _mapper.Map<UpdateMovieCommand>(movie);
        
            await _mediator.Send(command);

            foreach (var guid in movie.Genres)
                await AddMovieGenre(movie.Id, guid);
            
            scope.Complete();
        } 
    }

    private async Task ClearMovieGenres(Guid movieId)
    {
        var command = new ClearMovieGenresCommand(movieId);
        
        await _mediator.Send(command);
    }
    
    public async Task<Guid> Create(CreateMovieDto movie)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var command = _mapper.Map<CreateMovieCommand>(movie);
        
            var id = await _mediator.Send(command);

            foreach (var guid in movie.Genres)
                await AddMovieGenre(id, guid);
            
            scope.Complete();   
            
            return id;
        } 
    }
    
    private async Task AddMovieGenre(Guid movieId, Guid genreId)
    {
        var command = new AddMovieGenreCommand(movieId, genreId);
        
        await _mediator.Send(command);
    }
}