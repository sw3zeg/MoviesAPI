using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Movies;

namespace Movies.Persistence.Common.Commands.Movies;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    
    private readonly IDbConnection _db;

    public CreateMovieHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  INSERT INTO movie (id, title, release_year, country, budget, score, director_id, description, photo)
                  values (@Id, @Title, @ReleaseYear, @Country, @Budget, @Score, @DirectorId, @Description, @Photo)
                  RETURNING id
                  """;
        
        var queryParams = new
        {
            Id = request.Id,
            Title = request.Title,
            ReleaseYear = request.ReleaseYear,
            Country = request.Country,
            Budget = request.Budget,
            Score = request.Score,
            DirectorId = request.DirectorId,
            Description = request.Description,
            Photo = request.Photo
        };
        
        var id = await _db.ExecuteScalarAsync<Guid>(sql, queryParams);

        return id;
    }
}