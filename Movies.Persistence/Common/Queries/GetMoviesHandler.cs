using System.Data;
using AutoMapper;
using Dapper;
using MediatR;
using Movies.Application.Common.Queries;
using Movies.Domain.Entities;

namespace Movies.Persistence.Common.Queries;

public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, ICollection<MovieEntity>>
{
    private readonly IDbConnection _db;

    public GetMoviesHandler(IDbConnection db, IMapper mapper)
    {
        _db = db;
    }
    
    public async Task<ICollection<MovieEntity>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var sql = "SELECT * FROM movie " +
                  (request.Query.Length > 0 ? "WHERE title % @Query " : "") +
                  "LIMIT @Limit OFFSET @Offset";
        
        var queryParams = new
        {
            Query = request.Query,
            Limit = request.Limit,
            Offset = request.Offset
        };
        
        var response = await _db.QueryAsync<MovieEntity>(sql, queryParams);

        return response.ToList();
    }
}