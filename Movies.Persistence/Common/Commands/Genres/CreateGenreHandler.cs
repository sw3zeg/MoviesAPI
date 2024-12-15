using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Genres;

namespace Movies.Persistence.Common.Commands.Genres;

public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, Guid>
{
    private readonly IDbConnection _db;

    public CreateGenreHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  INSERT INTO genre (id, title)
                  values (@Id, @Title)
                  RETURNING id
                  """;
        
        var queryParams = new
        {
            Id = request.Id,
            Title = request.Title,
        };
        
        var id = await _db.ExecuteScalarAsync<Guid>(sql, queryParams);

        return id;
    }
}