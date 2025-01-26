using AutoMapper;
using e_Kart.Core.DTO;
using e_Kart.Core.Entities;

namespace e_Kart.Core.Mapper;
public class ApplicationUserMapper : Profile
{
    public ApplicationUserMapper()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.UserID, option => option.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Email, option => option.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, option => option.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, option => option.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Token, option => option.Ignore())
            .ForMember(dest => dest.Success, option => option.Ignore());
    }
}
