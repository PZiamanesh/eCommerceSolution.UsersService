namespace UsersMicroService.Core.Dtos;

public record UserDto
{
    public Guid UserID { get; set; }
    public string? Email { get; set; }
    public string? PersonName { get; set; }
    public GenderOptions? Gender { get; set; }
}
