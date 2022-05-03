using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class CommentListDto : Paginate<CommentDto>
{
    public List<CommentDto> Items { get; set; }
}