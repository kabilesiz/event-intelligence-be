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
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles([FromQuery] PageRequest pageRequest)
    {
        GetRoleListQuery getRoleListQuery = new GetRoleListQuery(pageRequest: pageRequest);
        var result = await _mediator.Send(getRoleListQuery);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        GetRoleByIdQuery getRoleQuery = new GetRoleByIdQuery(id);
        var result = await _mediator.Send(getRoleQuery);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] CreateRoleCommand createRoleCommand)
    {
        await _mediator.Send(createRoleCommand);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        DeleteRoleCommand deleteUserByIdCommand = new DeleteRoleCommand(id);
        var result = await _mediator.Send(deleteUserByIdCommand);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand role)
    {
        await _mediator.Send(role);
        return Ok();
    }
}