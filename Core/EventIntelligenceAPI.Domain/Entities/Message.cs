using EventIntelligenceAPI.Domain.Entities.Common;

namespace EventIntelligenceAPI.Domain.Entities;

public class Message : BaseEntity
{
    public int SenderUserId { get; set; }
    public User? SenderUser { get; set; }
    public int ReceiverUserId { get; set; }
    public User? ReceiverUser { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool isDeleted { get; set; }
}