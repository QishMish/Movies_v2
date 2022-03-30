using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetAsync(params object[] key)
        {
            return await _dbSet.FindAsync(key);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                return;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(params object[] key)
        {
            var entity = await GetAsync(key);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
