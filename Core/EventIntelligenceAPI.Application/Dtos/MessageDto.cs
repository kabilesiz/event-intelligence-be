namespace EventIntelligenceAPI.Application.Dtos;

public class MessageDto
{
    public int Id { get; set; }
    public int SenderUserId { get; set; }
    public int ReceiverUserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool isDeleted { get; set; }
}