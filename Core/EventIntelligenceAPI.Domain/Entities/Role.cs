using EventIntelligenceAPI.Domain.Entities.Common;

namespace EventIntelligenceAPI.Domain.Entities;

public class Role : BaseEntity
{
    public string Definition { get; set; }
    public List<User>? Users { get; set; }
}