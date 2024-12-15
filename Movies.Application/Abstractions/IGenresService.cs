using Movies.Application.Dto.genres;
using Movies.Domain.Entities;

namespace Movies.Application.Abstractions;

public interface IGenresService
{
    public Task<Guid> Create(CreateGenreDto genre);
    public Task<Int64> CreateMany(ICollection<CreateGenreDto> genres);
    public Task Update(UpdateGenreDto genre);
    public Task Delete(Guid id);
    public Task<ICollection<GetGenreDto>> Query(String query, 
        Int64 limit, Int64 offset);
}