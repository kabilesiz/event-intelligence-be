using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class UserListDto : Paginate<UserDto>
{
    public List<UserDto> Items { get; set; }
}