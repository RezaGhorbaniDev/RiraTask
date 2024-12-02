namespace RiraTask.Infrastructure.Repositories;

public class DataRepository(MongoDbContext ctx) : IDataRepository
{
    private IUserRepository? _users;

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(ctx);
            return _users;
        }
    }
}