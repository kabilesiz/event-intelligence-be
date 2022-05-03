using EventIntelligenceAPI.Domain.Entities.Common;

namespace EventIntelligenceAPI.Domain.Entities;

public class Event : BaseEntity
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<EventUser>? EventUsers { get; set; }
    public List<Comment>? Comments { get; set; }
}