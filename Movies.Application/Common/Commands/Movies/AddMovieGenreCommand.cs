using MediatR;

namespace Movies.Application.Common.Commands.Movies;

public class AddMovieGenreCommand : IRequest
{
    public Guid MovieId { get; set; }
    public Guid GenreId { get; set; }
    

    public AddMovieGenreCommand(Guid movieId, Guid genreId)
    {
        MovieId = movieId;
        GenreId = genreId;
    }
}