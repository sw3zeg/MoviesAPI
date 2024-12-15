using Microsoft.AspNetCore.Mvc;
using Movies.Application.Abstractions;
using Movies.Application.Dto.Directors;
using Movies.Application.Dto.Movies;
using Movies.Domain.Entities;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly IMoviesService _moviesService;

    public MoviesController(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }
    
    
    
    [HttpGet]
    public async Task<IActionResult> Query(
        [FromQuery] String query = "",
        [FromQuery] Int32 limit = 10,
        [FromQuery] Int64 offset = 0
    )
    {
        var genres = await _moviesService.Query(query, limit, offset);
        return Ok(genres);
    }
    
    [HttpPost("many")]
    public async Task<IActionResult> CreateMany(
        [FromBody] ICollection<CreateMovieDto> movies
    )
    {
        var count = await _moviesService.CreateMany(movies);
        var result = new Result($"All {count} genres was created successfully");
        return Ok(result);
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id
    )
    {
        await _moviesService.Delete(id);
        var result = new Result("Deleted successful");
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOne(
        [FromBody] CreateMovieDto movie
    )
    {
        var id = await _moviesService.Create(movie);
        var result = new Result($"Movie was created successfully: {id}");
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateMovieDto movie
    )
    {
        await _moviesService.Update(movie);
        var result = new Result("Update successful");
        return Ok(result);
    }
}