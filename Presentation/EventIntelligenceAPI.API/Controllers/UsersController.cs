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
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetUserListQuery getUserListQuery = new GetUserListQuery(pageRequest: pageRequest);
        var result = await _mediator.Send(getUserListQuery);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        GetUserByIdQuery getUserByIdQuery = new GetUserByIdQuery(id);
        var result = await _mediator.Send(getUserByIdQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserCommand createUserCommand)
    {
        await _mediator.Send(createUserCommand);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand user)
    {
        await _mediator.Send(user);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        DeleteUserCommand deleteUserByIdCommand = new DeleteUserCommand(id);
        var result = await _mediator.Send(deleteUserByIdCommand);
        return Ok(result);
    }
}

