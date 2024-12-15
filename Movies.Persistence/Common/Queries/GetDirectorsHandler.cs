using System.Data;
using AutoMapper;
using Dapper;
using MediatR;
using Movies.Application.Common.Queries.Genres;
using Movies.Domain.Entities;

namespace Movies.Persistence.Common.Queries;

public class GetDirectorsHandler : IRequestHandler<GetDirectorsQuery, ICollection<DirectorEntity>>
{
        private readonly IDbConnection _db;

        public GetDirectorsHandler(IDbConnection db, IMapper mapper)
        {
            _db = db;
        }
    
        public async Task<ICollection<DirectorEntity>> Handle(GetDirectorsQuery request, CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM director " +
                      (request.Query.Length > 0 ? 
                          "WHERE word_similarity(@Query, director.first_name || ' ' || director.last_name) > 0.5 " : "") +
                      "LIMIT @Limit OFFSET @Offset";
            
            var queryParams = new
            {
                Query = request.Query,
                Limit = request.Limit,
                Offset = request.Offset
            };
        
            var response = await _db.QueryAsync<DirectorEntity>(sql, queryParams);

            return response.ToList();
        }
}