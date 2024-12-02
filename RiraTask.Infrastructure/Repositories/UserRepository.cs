namespace RiraTask.Infrastructure.Repositories;

public class UserRepository(MongoDbContext context)
    : RepositoryBase<User>(context, "Users"), IUserRepository
{
}