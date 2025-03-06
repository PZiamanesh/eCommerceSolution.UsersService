using AutoMapper;
using eCommerce.Core.Dtos;
using eCommerce.Core.Entities;

namespace eCommerce.Core.MappingObjects;

public class ApplicationUserToUserDto : Profile
{
    public ApplicationUserToUserDto()
    {
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.PersonName, opt => opt.MapFrom(s => s.PersonName))
            .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender));
    }
}
