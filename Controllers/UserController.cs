using TestRelationship.Dtos;
using Microsoft.AspNetCore.Mvc;
using TestRelationship.Services;
namespace TestRelationship.Contetroller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _service { get; init; }
    public UserController(IUserService service) => _service = service;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int userId)
    {
        if (!await _service.UserExist(userId))
        {
            return NotFound();
        }

        var user = await _service.GetById(userId);
        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(UserCreateDto dto)
    {
        var user = await _service.Create(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { Id = user.UserId },
            user
        );
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Patch(int userId, UserUpdateDto dto)
    {
        var user = await _service.Update(userId, dto);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int userId)
    {
        await _service.Delete(userId);
        return NoContent();
    }
}