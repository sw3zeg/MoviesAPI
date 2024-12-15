using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Genres;

namespace Movies.Persistence.Common.Commands.Genres;

public class DeleteGenreHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly IDbConnection _db;

    public DeleteGenreHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  DELETE 
                  FROM genre
                  WHERE id = @Id
                  """;
        
        var queryParams = new { Id = request.Id};
        
        await _db.ExecuteAsync(sql, queryParams);
    }
}