using System.Data;
using AutoMapper;
using Dapper;
using MediatR;
using Movies.Application.Common.Queries;
using Movies.Domain.Entities;

namespace Movies.Persistence.Common.Queries;

public class GetMovieGenresHandler : IRequestHandler<GetMovieGenresQuery, ICollection<Guid>>
{
    private readonly IDbConnection _db;

    public GetMovieGenresHandler(IDbConnection db, IMapper mapper)
    {
        _db = db;
    }
    
    public async Task<ICollection<Guid>> Handle(GetMovieGenresQuery request, CancellationToken cancellationToken)
    {
        var sql = """
                  SELECT genre_id
                  FROM movie_genre
                  WHERE movie_id = @MovieId
                  """;
        
        var queryParams = new
        {
            MovieId = request.MovieId,
        };
        
        var response = await _db.QueryAsync<Guid>(sql, queryParams);

        return response.ToList();
    }
}