using System.Data;
using AutoMapper;
using Dapper;
using MediatR;
using Movies.Application.Common.Queries.Genres;
using Movies.Domain.Entities;

namespace Movies.Persistence.Common.Queries;

public class GetGenresHandler : IRequestHandler<GetGenresQuery, ICollection<GenreEntity>>
{
    private readonly IDbConnection _db;

    public GetGenresHandler(IDbConnection db, IMapper mapper)
    {
        _db = db;
    }
    
    public async Task<ICollection<GenreEntity>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        
        var sql = "SELECT * FROM genre " +
                  (request.Query.Length > 0 ? "WHERE title % @Query " : "") +
                  "LIMIT @Limit OFFSET @Offset";
        
        var queryParams = new
        {
            Query = request.Query,
            Limit = request.Limit,
            Offset = request.Offset
        };
        
        var response = await _db.QueryAsync<GenreEntity>(sql, queryParams);

        return response.ToList();
    }
}