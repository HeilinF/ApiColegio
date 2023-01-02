using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAync(string id);
        Task<T> GetByIdAync(int id);
        Task<T> GetByIdAync(byte id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> AddRangeAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> PatchAsync(T entity);
        void Delete(string id);
    }
}
