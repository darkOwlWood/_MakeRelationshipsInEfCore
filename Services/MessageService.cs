using AutoMapper;
using TestRelationship.Dtos;
using TestRelationship.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestRelationship.Services;

public class MessageService : IMessageService
{
    private IMapper _mapper { get; init; }
    private DbContextTestRelationship _context { get; init; }
    public MessageService(IMapper mapper, DbContextTestRelationship context) =>
        (_mapper, _context) = (mapper, context);

    public async Task<bool> MessageExist(int messageId) => (await _context.Messages.FindAsync(messageId)) is not null;

    public IEnumerable<MessageBaseDto> GetAll() =>
        _mapper.Map<IEnumerable<MessageBaseDto>>(
            _context.Messages
                .Include(m => m.Reciver)
                .Include(m => m.Sender)
            );

    public async Task<MessageBaseDto> GetMessageByMessageId(int messageId) =>
        _mapper.Map<MessageBaseDto>(
                await _context.Messages
                .Include(m => m.Reciver)
                .Include(m => m.Sender)
                .Where(m => m.MessageModelId == messageId)
                .FirstOrDefaultAsync()
            );

    public IEnumerable<MessageBaseDto> GetMessageByUserId(int senderId) =>
        _mapper.Map<IEnumerable<MessageBaseDto>>(
            _context.Messages
                .Include(m => m.Reciver)
                .Where(message => message.SenderId == senderId)
            );

    public async Task<MessageBaseDto> Create(MessageCreateDto dto)
    {
        var model = _mapper.Map<MessageModel>(dto);
        await _context.AddRangeAsync(model);
        await _context.SaveChangesAsync();
        await _context.Entry(model).Reference(m => m.Reciver).LoadAsync();
        await _context.Entry(model).Reference(m => m.Sender).LoadAsync();
        return _mapper.Map<MessageBaseDto>(model);
    }

    public async Task<MessageBaseDto> Update(int messageId, MessageUpdateDto dto)
    {
        var model = await _context.Messages.FindAsync(messageId);
        _mapper.Map(dto, model);
        model.UpdateDate = DateTimeOffset.Now;
        await _context.SaveChangesAsync();
        return _mapper.Map<MessageBaseDto>(model);
    }

    public async Task Delete(int messageId)
    {
        var model = await _context.Messages.FindAsync(messageId);
        if (model is not null)
        {
            _context.Messages.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
