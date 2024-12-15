using System.Data;
using Dapper;
using MediatR;
using Movies.Application.Common.Commands.Directors;

namespace Movies.Persistence.Common.Commands.Directors;

public class DeleteDirectorHandler: IRequestHandler<DeleteDirectorCommand>
{
        private readonly IDbConnection _db;

        public DeleteDirectorHandler(IDbConnection db)
        {
            _db = db;
        }
    
        public async Task Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            var sql = """
                      DELETE 
                      FROM director
                      WHERE id = @Id
                      """;
        
            var queryParams = new { Id = request.Id};
        
            await _db.ExecuteAsync(sql, queryParams);
        }
}