using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LearningDbContext _context;

        public GenericRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity) 
            => await _context.Set<T>().AddAsync(entity);


        public void Delete(T entity) 
            => _context.Set<T>().Remove(entity);


        public async Task<IEnumerable<T>> GetAllAsync() 
            => await _context.Set<T>().ToListAsync();


        public async Task<T?> GetAsync(int id) 
            => await _context.Set<T>().FindAsync(id);


        public void Update(T entity) 
            => _context.Set<T>().Update(entity);
    }
}
