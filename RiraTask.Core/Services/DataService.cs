using RiraTask.Core.Services.Interfaces;
using RiraTask.Infrastructure.Repositories.Interfaces;

namespace RiraTask.Core.Services;

public class DataService(IDataRepository repository) : IDataService
{
    private readonly Lazy<IUserService> _userService = new(() => new UserService(repository));

    public IUserService Users => _userService.Value;
}