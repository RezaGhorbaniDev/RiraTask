using RiraTask.Domain.Models;

namespace RiraTask.Core.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(string userId);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(string userId, User user);
    Task DeleteUserAsync(string userId);
}