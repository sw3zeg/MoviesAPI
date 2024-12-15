using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Directors;

namespace Movies.Persistence.Common.Commands.Directors;

public class UpdateDirectorHandler : IRequestHandler<UpdateDirectorCommand>
{
    private readonly IDbConnection _db;

    public UpdateDirectorHandler(IDbConnection db)
    {
        _db = db;
    }
    
    public async Task Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var sql = """
                  UPDATE director
                  SET first_name = @FirstName, 
                      last_name = @LastName,
                      birth_day = @BirthDate,
                      biography = @Biography,
                      photo = @Photo
                  WHERE id = @Id
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
        
        await _db.ExecuteAsync(sql, queryParams);
    }
}