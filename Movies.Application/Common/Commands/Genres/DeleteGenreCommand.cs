using MediatR;

namespace Movies.Application.Common.Commands.Genres;

public class DeleteGenreCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteGenreCommand(Guid id)
    {
        this.Id = id;
    }
}