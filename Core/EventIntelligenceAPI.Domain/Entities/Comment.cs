using EventIntelligenceAPI.Domain.Entities.Common;

namespace EventIntelligenceAPI.Domain.Entities;

public class Comment : BaseEntity
{
    public int UserId { get; set; }
    public int EventId { get; set; }
    public Event? Event { get; set; }
    public User? User { get; set; }
    public string Body { get; set; }
}