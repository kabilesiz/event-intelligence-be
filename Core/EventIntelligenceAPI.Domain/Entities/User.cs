using EventIntelligenceAPI.Domain.Entities.Common;

namespace EventIntelligenceAPI.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ushort Age { get; set; }
    public string Department { get; set; }
    public string Address { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public List<EventUser> EventUsers { get; set; }
    public List<Message>? ReceivedMessages { get; set; }
    public List<Message>? SentMessages { get; set; }
    public List<Comment>? Comments { get; set; }
}