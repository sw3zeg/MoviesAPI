using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Movies;

namespace Movies.Persistence.Common.Commands.Movies;

public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IDbConnection _db;

    public DeleteMovieHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  DELETE 
                  FROM movie
                  WHERE id = @Id
                  """;
        
        var queryParams = new { Id = request.Id};
        
        await _db.ExecuteAsync(sql, queryParams);
    }
}