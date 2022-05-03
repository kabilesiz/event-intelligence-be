using EventIntelligenceAPI.Application.Wrappers;

namespace EventIntelligenceAPI.Application.Dtos;

public class RoleListDto : Paginate<RoleDto>
{
    public List<RoleDto> Items { get; set; }
}