using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventIntelligenceAPI.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEvents([FromQuery] PageRequest pageRequest)
    {
        GetEventListQuery getUserListQuery = new GetEventListQuery(pageRequest: pageRequest);
        var result = await _mediator.Send(getUserListQuery);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(int id)
    {
        GetEventByIdQuery getEventByIdQuery = new GetEventByIdQuery(id);
        var result = await _mediator.Send(getEventByIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand createEventCommand)
    {
        var toReturn = await _mediator.Send(createEventCommand);
        return Created("",toReturn);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommand eventCommand)
    {
        await _mediator.Send(eventCommand);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        DeleteEventCommand deleteEventByIdCommand = new DeleteEventCommand(id);
        var result = await _mediator.Send(deleteEventByIdCommand);
        return Ok(result);
    }
}