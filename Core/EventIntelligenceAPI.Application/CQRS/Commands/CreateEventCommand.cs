using EventIntelligenceAPI.Application.Dtos;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.Commands;

public class CreateEventCommand: IRequest<EventDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}