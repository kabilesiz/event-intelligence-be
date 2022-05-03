namespace EventIntelligenceAPI.Application.Dtos;

public class CommentDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public string Body { get; set; }
}