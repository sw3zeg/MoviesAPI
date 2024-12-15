using MediatR;

namespace Movies.Application.Common.Commands.Movies;

public class ClearMovieGenresCommand : IRequest
{
    public Guid MovieId { get; set; }

    public ClearMovieGenresCommand(Guid movieId)
    {
        MovieId = movieId;
    }
}