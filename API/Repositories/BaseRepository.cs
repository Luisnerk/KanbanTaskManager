using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Data;
using Kanban.Entities;
using Kanban.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext _context;
    public BaseRepository(DataContext context)
    {
        _context = context;
    }
    
    public void add(T entity)
    {
        _context.Set<T>().Add(entity);

    }

    public virtual async Task<IEnumerable<T>> getListAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual void updateItem(T item)
    {
        _context.Set<T>().Update(item);
    }

    public async Task<int> saveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}