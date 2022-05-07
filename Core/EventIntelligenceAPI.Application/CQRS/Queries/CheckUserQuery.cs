using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Queries;

public class CheckUserQuery : IRequest<UserDto?>
{

    public string? Email { get; set; }
    public string? Password { get; set; } 
}