

namespace RiraTask.Infrastructure.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : ModelBase
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}