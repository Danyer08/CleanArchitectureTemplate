namespace Application.Common;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}