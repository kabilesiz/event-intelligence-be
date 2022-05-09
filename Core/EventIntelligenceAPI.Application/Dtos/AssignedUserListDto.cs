using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class AssignedUserListDto : Paginate<AssignedUserDto>
{
    public List<AssignedUserDto> Items { get; set; }
}