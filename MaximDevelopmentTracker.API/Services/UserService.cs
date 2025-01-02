using MaximDevelopmentTracker.API.DataContext;
using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Interfaces;
using MaximDevelopmentTracker.API.Models;

namespace MaximDevelopmentTracker.API.Services;

public class UserService: IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PasswordHash = userDto.PasswordHash,

       
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return Task.FromResult(new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
        });
    }

    public Task<bool> DeleteUserAsync(Guid id)
    {
        var user = _context.Users.Find(id);
        if( user == null )
        {
            return Task.FromResult(false);
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return Task.FromResult(true);
    }

    public Task<UserDto> GetUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUserAsync(Guid id, UserDto userDto)
    {
        throw new NotImplementedException();
    }
}
