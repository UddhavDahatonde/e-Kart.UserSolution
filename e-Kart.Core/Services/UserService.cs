using AutoMapper;
using e_Kart.Core.DTO;
using e_Kart.Core.Entities;
using e_Kart.Core.RepositoryContracts;
using e_Kart.Core.ServiceContracts;

namespace e_Kart.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? applicationUser = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (applicationUser == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(applicationUser) with { Success = true, Token = "Token" };

    }

    public async Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName,
            Gender = Enum.GetName(registerRequest.GenderOption)
        };
        ApplicationUser? applicationUser = await _userRepository.AddUser(user);

        if (applicationUser == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(applicationUser);
    }
}
