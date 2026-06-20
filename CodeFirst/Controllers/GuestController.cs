using CodeFirst.DTOs;
using CodeFirst.Exceptions;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestController : ControllerBase
{
    private readonly IDbService _db;
    public GuestController(IDbService db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? lastName = null)
        => Ok(await _db.GetAllAsync(lastName));

    [HttpPost]
    public async Task<IActionResult> Add(AddGuestDTO dto)
    {
        try
        {
            await _db.AddAsync(dto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }

}
