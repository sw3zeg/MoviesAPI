using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Movies;

namespace Movies.Persistence.Common.Commands.Movies;

public class ClearMovieGenresHandler : IRequestHandler<ClearMovieGenresCommand>
{
    private readonly IDbConnection _db;

    public ClearMovieGenresHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(ClearMovieGenresCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  DELETE FROM movie_genre 
                  WHERE movie_id = @MovieId
                  """;
        
        var queryParams = new
        {
            MovieId = request.MovieId,
        };
        
        await _db.ExecuteAsync(sql, queryParams);
    }
}