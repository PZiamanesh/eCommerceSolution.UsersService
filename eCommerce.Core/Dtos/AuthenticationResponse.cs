namespace eCommerce.Core.Dtos;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    GenderOptions? Gender,
    string? Token,
    bool Success
    );
