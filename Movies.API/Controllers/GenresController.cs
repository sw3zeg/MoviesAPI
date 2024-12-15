using Microsoft.AspNetCore.Mvc;
using Movies.Application.Abstractions;
using Movies.Application.Dto.genres;
using Movies.Domain.Entities;

namespace Movies.API.Controllers;


[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IGenresService _genresService;

    public GenresController(IGenresService genresService)
    {
        _genresService = genresService;
    }

    
    [HttpGet]
    public async Task<IActionResult> Query(
        [FromQuery] String query = "",
        [FromQuery] Int32 limit = 10,
        [FromQuery] Int64 offset = 0
        )
    {
        var genres = await _genresService.Query(query, limit, offset);
        return Ok(genres);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id
        )
    {
        await _genresService.Delete(id);
        return Ok();
    }
    

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateGenreDto genre
        )
    {
        await _genresService.Update(genre);
        return Ok();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateOne(
        [FromBody] CreateGenreDto genre
    )
    {
        var id = await _genresService.Create(genre);
        return Ok(id);
    }
    
    
    [HttpPost("many")]
    public async Task<IActionResult> CreateMany(
        [FromBody] ICollection<CreateGenreDto> genres
    )
    {
        var count = await _genresService.CreateMany(genres);
        return Ok(count);
    }
}