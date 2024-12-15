using MediatR;

namespace Movies.Application.Common.Commands.Movies;

public class UpdateMovieCommand : IRequest
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public Int64 ReleaseYear { get; set; }
    public String Country { get; set; }
    public Int64 Budget { get; set; }
    public Int64 Score { get; set; }
    public Guid DirectorId { get; set; }
    public String Description { get; set; }
    public String Photo { get; set; }
}