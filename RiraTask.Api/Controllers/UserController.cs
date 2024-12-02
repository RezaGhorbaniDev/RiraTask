using AutoMapper;
using Grpc.Core;
using RiraTask.Api.Protos;
using RiraTask.Core.Services.Interfaces;

namespace RiraTask.Api.Controllers;

public class UserController(IDataService db, IMapper mapper)
    : UserGRPCService.UserGRPCServiceBase
{
    #region GetUsers

    /// <summary>
    /// Returns all users
    /// </summary>
    public override async Task<GetUsersResponse> GetUsers(Empty request, ServerCallContext context)
    {
        var response = new GetUsersResponse();

        var users = await db.Users.GetUsersAsync();
        response.Users.AddRange(mapper.Map<IEnumerable<User>>(users));

        return response;
    }

    #endregion

    #region GetUserById

    /// <summary>
    /// Returns a user by given userId
    /// </summary>
    public override async Task<GetUserResponse> GetUserById(GetUserByIdRequest request, ServerCallContext context)
    {
        var response = new GetUserResponse();

        var user = await db.Users.GetUserByIdAsync(request.UserId);
        response.User = mapper.Map<User>(user);

        return response;
    }

    #endregion

    #region CreateUser

    /// <summary>
    /// Creates a user by given info
    /// </summary>
    public override async Task<EmptyResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        var user = mapper.Map<Domain.Models.User>(request.User);
        await db.Users.CreateUserAsync(user);

        return new EmptyResponse();
    }

    #endregion

    #region UpdateUser

    /// <summary>
    /// Updates the given user
    /// </summary>
    public override async Task<EmptyResponse> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        var user = mapper.Map<Domain.Models.User>(request.User);
        await db.Users.UpdateUserAsync(request.UserId, user);

        return new EmptyResponse();
    }

    #endregion

    #region DeleteUser

    /// <summary>
    /// Deletes the user
    /// </summary>
    public override async Task<EmptyResponse> DeleteUser(DeleteUserRequest request, ServerCallContext context)
    {
        await db.Users.DeleteUserAsync(request.UserId);
        return new EmptyResponse();
    }

    #endregion
}