using Microsoft.AspNetCore.Mvc;
using Movies.Application.Abstractions;
using Movies.Application.Dto.Directors;
using Movies.Application.Dto.genres;
using Movies.Domain.Entities;

namespace Movies.API.Controllers;


[ApiController]
[Route("api/directors")]
public class DirectorsController : ControllerBase
{
    
    private readonly IDirectorsService _directorsService;

    public DirectorsController(IDirectorsService directorsService)
    {
        _directorsService = directorsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Query(
        [FromQuery] String query = "",
        [FromQuery] Int32 limit = 10,
        [FromQuery] Int64 offset = 0
    )
    {
        var genres = await _directorsService.Query(query, limit, offset);
        return Ok(genres);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid id
    )
    {
        await _directorsService.Delete(id);
        var result = new Result("Deleted successful");
        return Ok(result);
    }
    

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateDirectorDto director
    )
    {
        await _directorsService.Update(director);
        var result = new Result("Update successful");
        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateOne(
        [FromBody] CreateDirectorDto director
    )
    {
        var id = await _directorsService.Create(director);
        var result = new Result($"Genre was created successfully: {id}");
        return Ok(result);
    }
    
    
    [HttpPost("many")]
    public async Task<IActionResult> CreateMany(
        [FromBody] ICollection<CreateDirectorDto> director
    )
    {
        var count = await _directorsService.CreateMany(director);
        var result = new Result($"All {count} genres was created successfully");
        return Ok(result);
    }
}