using Movies.Domain.Entities;

namespace Movies.Application.Dto.Movies;

public record GetMovieDto
{
    public Guid Id { get; init; }
    public String Title { get; init; }
    public Int64 ReleaseYear { get; init; }
    public String Country { get; init; }
    public Int64 Budget { get; init; }
    public Int64 Score { get; init; }
    public Guid DirectorId { get; init; }
    public ICollection<Guid> Genres { get; init; }
    public String Description { get; set; }
    public String Photo { get; set; }
    
    public GetMovieDto(MovieEntity movie, ICollection<Guid> genres)
    {
        this.Id = movie.id;
        this.Title = movie.title;
        this.ReleaseYear = movie.release_year;
        this.Country = movie.country;
        this.Budget = movie.budget;
        this.Score = movie.score;
        this.DirectorId = movie.director_id;
        this.Genres = genres;
        this.Description = movie.description;
        this.Photo = movie.photo;
    }
}