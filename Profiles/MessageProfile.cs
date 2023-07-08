using AutoMapper;
using TestRelationship.Dtos;
using TestRelationship.Models;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<MessageCreateDto, MessageModel>();
        CreateMap<MessageModel, MessageBaseDto>()
            .ForMember(dst => dst.MessageId, opt => opt.MapFrom(src => src.MessageModelId));
        CreateMap<MessageUpdateDto, MessageModel>()
            .ForAllMembers(opt => opt.Condition((src, dst, value) => value is not null));
    }
}