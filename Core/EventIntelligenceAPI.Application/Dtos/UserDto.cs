namespace EventIntelligenceAPI.Application.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ushort Age { get; set; }
    public string Department { get; set; }
    public string Address { get; set; }
    public int RoleId { get; set; }
    public string? RoleDefinition { get; set; }
}