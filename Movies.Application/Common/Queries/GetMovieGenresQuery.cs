using MediatR;

namespace Movies.Application.Common.Queries;

public class GetMovieGenresQuery : IRequest<ICollection<Guid>>
{
    public Guid MovieId { get; set; }

    public GetMovieGenresQuery(Guid id)
    {
        MovieId = id;
    }
}