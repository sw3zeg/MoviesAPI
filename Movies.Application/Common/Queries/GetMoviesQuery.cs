using MediatR;
using Movies.Application.Dto.Movies;
using Movies.Domain.Entities;

namespace Movies.Application.Common.Queries;

public class GetMoviesQuery : IRequest<ICollection<MovieEntity>>
{
    public String Query { get; set; }
    public Int64 Limit { get; set; }
    public Int64 Offset { get; set; }

    public GetMoviesQuery(String qurey, Int64 limit, Int64 offset)
    {
        Query = qurey;
        Limit = limit;
        Offset = offset;
    }
}