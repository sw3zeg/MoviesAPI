using Movies.Application.Dto.Movies;

namespace Movies.Application.Abstractions;

public interface IMoviesService
{
    public Task<Guid> Create(CreateMovieDto movie);
    public Task<Int64> CreateMany(ICollection<CreateMovieDto> movie);
    public Task Update(UpdateMovieDto movie);
    public Task Delete(Guid id);
    public Task<ICollection<GetMovieDto>> Query(String query, 
        Int64 limit, Int64 offset);
}