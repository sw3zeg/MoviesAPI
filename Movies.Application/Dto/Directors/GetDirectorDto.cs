namespace Movies.Application.Dto.Directors;

public record GetDirectorDto
{
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public String Biography { get; set; }
    public String Photo { get; set; }

    public GetDirectorDto(Guid id, string firstName, string lastName, DateTime birthDate, String biography, String Photo)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Biography = biography;
        Photo = Photo;
    }
}