using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Directors;

namespace Movies.Persistence.Common.Commands.Directors;

public class CreateDirectorHandler : IRequestHandler<CreateDirectorCommand, Guid>
{
    
    private readonly IDbConnection _db;

    public CreateDirectorHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task<Guid> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  INSERT INTO director (id, first_name, last_name, birth_day, biography, photo)
                  values (@Id, @FirstName, @LastName, @BirthDate, @Biography, @Photo)
                  RETURNING id
                  """;
        
        var queryParams = new
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Biography = request.Biography,
            Photo = request.Photo
        };
        
        var id = await _db.ExecuteScalarAsync<Guid>(sql, queryParams);

        return id;
    }
}