namespace Movies.Domain.Entities;

public record GenreEntity
{
    public Guid id { get; set; }
    public String title { get; set; }
}