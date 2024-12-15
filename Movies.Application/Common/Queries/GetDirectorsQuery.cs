using MediatR;
using Movies.Application.Dto.Directors;
using Movies.Application.Dto.genres;
using Movies.Domain.Entities;

namespace Movies.Application.Common.Queries.Genres;

public class GetDirectorsQuery : IRequest<ICollection<DirectorEntity>>
{
    public String Query { get; set; }
    public Int64 Limit { get; set; }
    public Int64 Offset { get; set; }

    public GetDirectorsQuery(String qurey, Int64 limit, Int64 offset)
    {
        Query = qurey;
        Limit = limit;
        Offset = offset;
    }
}