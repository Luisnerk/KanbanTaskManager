using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Entities;

namespace Kanban.Interfaces;
public interface IBaseRepository<T> where T:BaseEntity
{
    void Add(T entity);
    Task<int> SaveAsync();
    Task<IEnumerable<T>> GetListAsync(); 
}