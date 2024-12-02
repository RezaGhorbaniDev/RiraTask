using MongoDB.Bson;
using RiraTask.Core.Services.Interfaces;
using RiraTask.Domain.Models;
using RiraTask.Infrastructure.Repositories.Interfaces;

namespace RiraTask.Core.Services;

public class UserService(IDataRepository rep) : ServiceBase(rep), IUserService
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _rep.Users.GetAllAsync();
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        return await _rep.Users.GetByIdAsync(userId);
    }

    public async Task CreateUserAsync(User user)
    {
        
        user.Id = ObjectId.GenerateNewId().ToString();
        await _rep.Users.CreateAsync(user);
    }

    public async Task UpdateUserAsync(string userId, User user)
    {
        await _rep.Users.UpdateAsync(userId, user);
    }

    public async Task DeleteUserAsync(string userId)
    {
        await _rep.Users.DeleteAsync(userId);
    }
}