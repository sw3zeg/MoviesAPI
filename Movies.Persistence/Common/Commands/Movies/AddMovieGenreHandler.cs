using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Movies;

namespace Movies.Persistence.Common.Commands.Movies;

public class AddMovieGenreHandler : IRequestHandler<AddMovieGenreCommand>
{
    private readonly IDbConnection _db;

    public AddMovieGenreHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(AddMovieGenreCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  INSERT INTO movie_genre (movie_id, genre_id)
                  values (@MovieId, @GenreId)
                  """;
        
        var queryParams = new
        {
            MovieId = request.MovieId,
            GenreId = request.GenreId
        };
        
        await _db.ExecuteScalarAsync(sql, queryParams);
    }
}