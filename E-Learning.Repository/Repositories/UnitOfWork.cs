using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Repository.Data;
using System.Collections;

namespace E_Learning.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearningDbContext _context;
        private readonly Hashtable _repositories;

        public UnitOfWork(LearningDbContext context, Hashtable repositories)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public async Task<int> CompeleteAsync()
        => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
         => await _context.DisposeAsync();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var typeName = typeof(T).Name;
            if (_repositories.ContainsKey(typeName)) return (_repositories[typeName] as GenericRepository<T>)!;

            var repo = new GenericRepository<T>(_context);
            _repositories.Add(typeName, repo);
            return repo;
        }
    }
}
