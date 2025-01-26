namespace e_Kart.Core.DTO;
public record AuthenticationResponse(
    Guid UserID,
    string? Email,
    string? PersonName,
    string? Token,
    string? Gender,
    bool Success
)
{
    public AuthenticationResponse() : this(default, default, default, default, default, default)
    {

    }
}