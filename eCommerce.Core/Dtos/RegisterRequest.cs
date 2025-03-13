namespace UsersMicroService.Core.Dtos;

public record RegisterRequest
{
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? PersonName { get; init; }
    public GenderOptions? Gender { get; init; }
}