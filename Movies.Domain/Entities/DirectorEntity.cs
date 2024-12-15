namespace Movies.Domain.Entities;

public record DirectorEntity
{
    public Guid id { get; set; }
    public String first_name { get; set; }
    public String last_name { get; set; }
    public DateTime birth_day { get; set; }
    public String biography { get; set; }
    public String photo { get; set; }
}