namespace E_Learning.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> CompeleteAsync();
    }
}
