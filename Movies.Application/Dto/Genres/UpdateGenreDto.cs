namespace Movies.Application.Dto.genres;

public record UpdateGenreDto
{
    public Guid Id { get; init; }
    public String Title { get; init; }
}