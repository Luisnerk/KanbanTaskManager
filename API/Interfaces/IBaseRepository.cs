using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Entities;

namespace Kanban.Interfaces;
public interface IBaseRepository<T> where T:BaseEntity
{
    void add(T entity);
    Task<int> saveAsync();
    Task<IEnumerable<T>> getListAsync(); 
    void updateItem(T item);
}