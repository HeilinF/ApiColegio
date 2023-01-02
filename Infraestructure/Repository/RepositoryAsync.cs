
using Domain.Context;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository;

public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly ConexionSQLServer _context;

    public RepositoryAsync(ConexionSQLServer context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public Task<T> AddRangeAsync(List<T> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        var entity = _context.Set<T>().Find(id);

        _context.Remove(entity);

        _context.SaveChanges();
    }

    public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public Task<T> GetByIdAync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAync(int id) => await _context.Set<T>().FindAsync(id);

    public Task<T> GetByIdAync(byte id)
    {
        throw new NotImplementedException();
    }

    public Task<T> PatchAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        _context.Update(entity).State = EntityState.Modified;

         _context.SaveChanges();

        return Task.FromResult(entity);
    }
}
