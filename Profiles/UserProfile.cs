using AutoMapper;
using TestRelationship.Dtos;
using TestRelationship.Models;
namespace TestRelationship.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDto, UserModel>();
        CreateMap<UserModel, UserBaseDto>()
            .ForMember(src => src.UserId, opt => opt.MapFrom(src => src.UserModelId));
        CreateMap<UserUpdateDto, UserModel>()
            .ForAllMembers(opt => opt.Condition((src, dst, value) => value is not null));
    }
}