using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class MessageListDto : Paginate<MessageDto>
{
    public List<MessageDto> Items { get; set; }
}