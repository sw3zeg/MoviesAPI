namespace Movies.Application.Dto.Directors;

public record UpdateDirectorDto
{
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public String Biography { get; set; }
    public String Photo { get; set; }
}