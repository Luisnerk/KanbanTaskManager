using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Data;
using Kanban.Entities;
using Kanban.Interfaces;

namespace Kanban.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext _context;
    public BaseRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);

    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}