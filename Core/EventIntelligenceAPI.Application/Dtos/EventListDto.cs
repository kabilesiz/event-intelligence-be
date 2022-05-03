using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class EventListDto : Paginate<EventDto>
{
    public List<EventDto> Items { get; set; }
}