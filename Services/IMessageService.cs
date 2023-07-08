using TestRelationship.Dtos;
namespace TestRelationship.Services;

public interface IMessageService
{
    Task<bool> MessageExist(int messageId);
    IEnumerable<MessageBaseDto> GetAll();
    Task<MessageBaseDto> GetMessageByMessageId(int messageId);
    IEnumerable<MessageBaseDto> GetMessageByUserId(int senderId);
    Task<MessageBaseDto> Create(MessageCreateDto dto);
    Task<MessageBaseDto> Update(int messageId, MessageUpdateDto dto);
    Task Delete(int messageId);
}
