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
public class EventUsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventUsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetEventUsers([FromQuery] PageRequest pageRequest)
    {
        GetEventUserListQuery getEventUsersListQuery = new GetEventUserListQuery(pageRequest: pageRequest);
        var result = await _mediator.Send(getEventUsersListQuery);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventUsersByID(int id)
    {
        GetEventUserByIdQuery getEventUsersByIdQuery = new GetEventUserByIdQuery(id);
        var result = await _mediator.Send(getEventUsersByIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEventUser([FromBody] CreateEventUserCommand createEventUserCommand)
    {
        await _mediator.Send(createEventUserCommand);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateEventUser([FromBody] UpdateEventUserCommand eventUser)
    {
        await _mediator.Send(eventUser);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        DeleteEventUserCommand deleteEventUserByIdCommand = new DeleteEventUserCommand(id);
        var result = await _mediator.Send(deleteEventUserByIdCommand);
        return Ok(result);
    }
}