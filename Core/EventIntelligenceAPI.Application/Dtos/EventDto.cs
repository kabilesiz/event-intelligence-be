namespace EventIntelligenceAPI.Application.Dtos;

public class EventDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}