namespace E_Learning.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task AddAsync(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
