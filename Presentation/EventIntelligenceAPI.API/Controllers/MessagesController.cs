using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventIntelligenceAPI.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMessage([FromQuery] PageRequest pageRequest)
    {
        GetMessageListQuery getMessageListQuery = new GetMessageListQuery(pageRequest: pageRequest);
        var result = await _mediator.Send(getMessageListQuery);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMessageById(int id)
    {
        GetMessageByIdQuery getMessageByIdQuery = new GetMessageByIdQuery(id);
        var result = await _mediator.Send(getMessageByIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    
    [HttpGet("{id}/received")]
    public async Task<IActionResult> GetMessagesByReceiverId([FromQuery] PageRequest pageRequest, int id)
    {
        GetMessageListByReceiverIdQuery getMessageByReceiverIdQuery = new GetMessageListByReceiverIdQuery(id, pageRequest);
        var result = await _mediator.Send(getMessageByReceiverIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    
    [HttpGet("{id}/sent")]
    public async Task<IActionResult> GetMessagesBySenderId([FromQuery] PageRequest pageRequest, int id)
    {
        GetMessageListBySenderIdQuery getMessageListBySenderIdQuery = new GetMessageListBySenderIdQuery(id, pageRequest);
        var result = await _mediator.Send(getMessageListBySenderIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpsertMessage([FromBody] CreateMessageCommand createMessageCommand)
    {
        await _mediator.Send(createMessageCommand);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageCommand message)
    {
        await _mediator.Send(message);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        DeleteMessageCommand deleteUserByIdCommand = new DeleteMessageCommand(id);
        var result = await _mediator.Send(deleteUserByIdCommand);
        return Ok(result);
    }
}