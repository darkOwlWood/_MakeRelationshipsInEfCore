using AutoMapper;
using TestRelationship.Dtos;
using TestRelationship.Models;
namespace TestRelationship.Services;

public class UserService : IUserService
{
    private IMapper _mapper { get; init; }
    private DbContextTestRelationship _context { get; init; }
    public UserService(IMapper mapper, DbContextTestRelationship context) =>
        (_mapper, _context) = (mapper, context);

    public async Task<bool> UserExist(int userId) => (await _context.Users.FindAsync(userId)) is not null;

    public IEnumerable<UserBaseDto> GetAll() => _mapper.Map<IEnumerable<UserBaseDto>>(_context.Users.ToList());

    public async Task<UserBaseDto> GetById(int UserId) => _mapper.Map<UserBaseDto>(await _context.Users.FindAsync(UserId));

    public async Task<UserBaseDto> Create(UserCreateDto dto)
    {
        var model = _mapper.Map<UserModel>(dto);
        await _context.Users.AddRangeAsync(model);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserBaseDto>(model);
    }

    public async Task<UserBaseDto> Update(int userId, UserUpdateDto dto)
    {
        var model = await _context.Users.FindAsync(userId);
        _mapper.Map(dto, model);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserBaseDto>(model);
    }

    public async Task Delete(int userId)
    {
        var model = await _context.Users.FindAsync(userId);
        if (model is not null)
        {
            _context.Users.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}