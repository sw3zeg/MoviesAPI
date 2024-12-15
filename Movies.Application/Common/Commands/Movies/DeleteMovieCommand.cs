using MediatR;

namespace Movies.Application.Common.Commands.Movies;

public class DeleteMovieCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteMovieCommand(Guid id)
    {
        this.Id = id;
    }
}