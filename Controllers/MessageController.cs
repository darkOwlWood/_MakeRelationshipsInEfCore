using TestRelationship.Dtos;
using Microsoft.AspNetCore.Mvc;
using TestRelationship.Services;
namespace TestRelationship.Contetroller;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private IMessageService _service { get; init; }
    public MessageController(IMessageService service) => _service = service;

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_service.GetAll());


    [HttpGet("by-message-id/{messageId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByMessageId(int messageId)
    {
        if (!await _service.MessageExist(messageId))
        {
            return NotFound();
        }

        var model = await _service.GetMessageByMessageId(messageId);
        return Ok(model);
    }

    [HttpGet("by-user-id/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetByUserId(int userId) => Ok(_service.GetMessageByUserId(userId));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(MessageCreateDto dto)
    {
        var model = await _service.Create(dto);
        return CreatedAtAction(
            nameof(GetByMessageId),
            new { messageId = model.MessageId },
            model
        );
    }

    [HttpPatch("{messageId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Patch(int messageId, MessageUpdateDto dto)
    {
        var model = await _service.Update(messageId, dto);
        return Ok(model);
    }

    [HttpDelete("{messageId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int messageId)
    {
        await _service.Delete(messageId);
        return NoContent();
    }
}