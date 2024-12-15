using MediatR;

namespace Movies.Application.Common.Commands.Genres;

public class CreateGenreCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public String Title { get; set; }
}