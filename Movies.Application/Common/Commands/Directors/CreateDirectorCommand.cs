using MediatR;

namespace Movies.Application.Common.Commands.Directors;

public class CreateDirectorCommand: IRequest<Guid>
{
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public String Biography { get; set; }
    public String Photo { get; set; }
}