namespace Movies.Application.Dto.Movies;

public record CreateMovieDto
{
    public String Title { get; init; }
    public Int64 ReleaseYear { get; init; }
    public String Country { get; init; }
    public Int64 Budget { get; init; }
    public Int64 Score { get; init; }
    public Guid DirectorId { get; init; }
    public ICollection<Guid> Genres { get; init; }
    public String Description { get; set; }
    public String Photo { get; set; }
}