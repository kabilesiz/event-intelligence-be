using EventIntelligenceAPI.Domain.Entities.Common;

namespace EventIntelligenceAPI.Domain.Entities;

public class EventUser : BaseEntity
{
    public int UserId { get; set; }

    public User? User { get; set; } 

    public int EventId { get; set; }

    public Event? Event { get; set; } 
}