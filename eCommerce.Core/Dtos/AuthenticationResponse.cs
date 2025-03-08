namespace eCommerce.Core.Dtos;

public record AuthenticationResponse
{
    public Guid UserID { get; init; }
    public string? Email { get; init; }
    public string? PersonName { get; init; }
    public GenderOptions? Gender { get; init; }
    public string? Token { get; init; }
    public bool Success { get; init; }
}
