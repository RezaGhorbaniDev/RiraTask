namespace RiraTask.Infrastructure.Repositories.Interfaces;

public interface IDataRepository
{
    IUserRepository Users { get; }
}