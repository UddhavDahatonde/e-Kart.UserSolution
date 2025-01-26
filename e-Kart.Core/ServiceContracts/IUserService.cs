using e_Kart.Core.DTO;

namespace e_Kart.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest);
}
