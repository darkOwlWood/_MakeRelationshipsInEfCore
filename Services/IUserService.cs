using TestRelationship.Dtos;
namespace TestRelationship.Services;

public interface IUserService
{
    Task<bool> UserExist(int userId);
    IEnumerable<UserBaseDto> GetAll();
    Task<UserBaseDto> GetById(int UserId);
    Task<UserBaseDto> Create(UserCreateDto dto);
    Task<UserBaseDto> Update(int userId, UserUpdateDto dto);
    Task Delete(int userId);
}