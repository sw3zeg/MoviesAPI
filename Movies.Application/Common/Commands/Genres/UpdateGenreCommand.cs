using MediatR;

namespace Movies.Application.Common.Commands.Genres;

public class UpdateGenreCommand : IRequest
{
    public Guid Id { get; set; }
    public String Title { get; set; }
}