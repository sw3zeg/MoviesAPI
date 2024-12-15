using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Genres;

namespace Movies.Persistence.Common.Commands.Genres;

public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand>
{
    private readonly IDbConnection _db;

    public UpdateGenreHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  UPDATE genre
                  SET title = @Title
                  WHERE id = @Id
                  """;
        
        var queryParams = new
        {
            Id = request.Id,
            Title = request.Title
        };
        
        await _db.ExecuteAsync(sql, queryParams);
    }
}