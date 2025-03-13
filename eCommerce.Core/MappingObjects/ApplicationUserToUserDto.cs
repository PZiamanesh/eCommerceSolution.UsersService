using AutoMapper;
using UsersMicroService.Core.Dtos;
using UsersMicroService.Core.Entities;

namespace UsersMicroService.Core.MappingObjects;

public class ApplicationUserToUserDto : Profile
{
    public ApplicationUserToUserDto()
    {
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(d => d.UserID, opt => opt.MapFrom(s => s.UserID))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.PersonName, opt => opt.MapFrom(s => s.PersonName))
            .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender));
    }
}
