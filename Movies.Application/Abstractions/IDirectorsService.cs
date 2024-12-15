using Movies.Application.Dto.Directors;

namespace Movies.Application.Abstractions;

public interface IDirectorsService
{
    public Task<Guid> Create(CreateDirectorDto director);
    public Task<Int64> CreateMany(ICollection<CreateDirectorDto> directors);
    public Task Update(UpdateDirectorDto director);
    public Task Delete(Guid id);
    public Task<ICollection<GetDirectorDto>> Query(String query, 
        Int64 limit, Int64 offset);
}