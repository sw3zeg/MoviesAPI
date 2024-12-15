using MediatR;

namespace Movies.Application.Common.Commands.Directors;

public class DeleteDirectorCommand : IRequest
{
    public Guid Id { get; set; }
    
    public DeleteDirectorCommand(Guid id)
    {
        this.Id = id;
    }
}