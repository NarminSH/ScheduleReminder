using System;
using Microsoft.EntityFrameworkCore;
using ScheduleReminderApp.DAL;
using ScheduleReminderApp.Repositories.Abstraction;
using ScheduleReminderApp.Utilities.Exceptions;

namespace ScheduleReminderApp.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            else { throw new EntityNotFoundException($"Entity with id: {id} is not found!"); }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //return expression != null ? await _dbSet.AsNoTracking().ToListAsync()
            //    : _dbSet.Where(expression);
            var result = await _dbSet.AsNoTracking().ToListAsync();
            return result;
            //todo add if else statement
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            if (await _context.SaveChangesAsync() >= 1) { return true; }
            else { return false; }
        }
    }
}

