using MongoDB.Bson;
using RiraTask.Core.Exceptions;
using RiraTask.Core.Services.Interfaces;
using RiraTask.Domain.Models;

namespace RiraTask.Core.Services;

public class UserService(IDataRepository rep) : ServiceBase(rep), IUserService
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _rep.Users.GetAllAsync();
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        var user = await _rep.Users.GetByIdAsync(userId);
        if (user == null)
            throw new NotFoundException("User not found.");

        return user;
    }

    public async Task CreateUserAsync(User user)
    {
        user.Id = ObjectId.GenerateNewId().ToString();
        await _rep.Users.CreateAsync(user);
    }

    public async Task UpdateUserAsync(string userId, User user)
    {
        if (string.IsNullOrEmpty(userId) || userId != user.Id)
            throw new NotFoundException("User not found.");
        
        await _rep.Users.UpdateAsync(userId, user);
    }

    public async Task DeleteUserAsync(string userId)
    {
        await _rep.Users.DeleteAsync(userId);
    }
}