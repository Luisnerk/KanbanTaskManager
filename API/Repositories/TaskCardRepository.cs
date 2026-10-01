using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Data;
using Kanban.Entities;
using Kanban.Interfaces;

namespace Kanban.Repositories;
public class TaskCardRepository : BaseRepository<TaskCard>, ITaskCardRepository
{
    public TaskCardRepository(DataContext context) : base(context) {}
}