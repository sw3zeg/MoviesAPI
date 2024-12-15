namespace Movies.Domain.Entities;

public record MovieEntity
{
    public Guid id { get; init; }
    public string title { get; init; }
    public long release_year { get; init; }
    public string country { get; init; }
    public long budget { get; init; }
    public long score { get; init; }
    public Guid director_id { get; init; }
    public String description { get; set; }
    public String photo { get; set; }
}