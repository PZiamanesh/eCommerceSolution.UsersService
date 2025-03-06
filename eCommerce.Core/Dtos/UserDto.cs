namespace eCommerce.Core.Dtos;

public record UserDto
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? PersonName { get; set; }
    public GenderOptions? Gender { get; set; }
}
