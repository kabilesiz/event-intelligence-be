namespace EventIntelligenceAPI.Application.Dtos;

public class AssignedUserDto
{
    public int EventId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public bool IsExist { get; set; }
}