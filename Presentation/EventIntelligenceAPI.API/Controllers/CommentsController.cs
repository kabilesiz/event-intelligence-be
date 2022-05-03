using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventIntelligenceAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetComments([FromQuery] PageRequest pageRequest)
    {
        GetCommentListQuery getCommentListQuery = new GetCommentListQuery(pageRequest: pageRequest);
        var result = await _mediator.Send(getCommentListQuery);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        GetCommentByIdQuery getCommentByIdQuery = new GetCommentByIdQuery(id);
        var result = await _mediator.Send(getCommentByIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand createCommentCommand)
    {
        await _mediator.Send(createCommentCommand);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand updateCommentCommand)
    {
        await _mediator.Send(updateCommentCommand);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        DeleteCommentCommand deleteCommentByIdCommand = new DeleteCommentCommand(id);
        var result = await _mediator.Send(deleteCommentByIdCommand);
        return Ok(result);
    }
    
}