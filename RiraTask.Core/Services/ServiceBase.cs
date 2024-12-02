namespace RiraTask.Core.Services;

public abstract class ServiceBase(IDataRepository rep)
{
    protected readonly IDataRepository _rep = rep;
}