namespace Movies.Application.Dto.genres;

public record GetGenreDto
{
    public Guid Id { get; init; }
    public String Title { get; init; }
}