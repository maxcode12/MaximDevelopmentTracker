using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Models;

namespace MaximDevelopmentTracker.API.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid id);
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto> CreateUserAsync(User userDto);
    Task<UserDto> UpdateUserAsync(Guid id, User userDto);
    Task<bool> DeleteUserAsync(Guid id);
}
