namespace e_Kart.Core.DTO;

public record RegisterRequest(string? Email, string? Password, string? PersonName, GenderOptions GenderOption);
