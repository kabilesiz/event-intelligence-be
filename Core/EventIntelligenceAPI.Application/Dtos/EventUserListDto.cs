using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class EventUserListDto : Paginate<EventUserDto>
{
    public List<EventUserDto> Items { get; set; }
}