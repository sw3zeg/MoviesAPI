using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Movies;

namespace Movies.Persistence.Common.Commands.Movies;

public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand>
{
    
    private readonly IDbConnection _db;

    public UpdateMovieHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  UPDATE movie
                  SET title = @Title,
                      release_year = @ReleaseYear,
                      country = @Country,
                      budget = @Budget,
                      score = @Score,
                      director_id = @DirectorId,
                      description = @Description,
                      photo = @Photo
                  WHERE id = @Id 
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
        
        var id = await _db.ExecuteAsync(sql, queryParams);
    }
}