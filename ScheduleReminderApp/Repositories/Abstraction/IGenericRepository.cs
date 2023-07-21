using System;
namespace ScheduleReminderApp.Repositories.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> UpdateAsync(T entity);
    }
}

