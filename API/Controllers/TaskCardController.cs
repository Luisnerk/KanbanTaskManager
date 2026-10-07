using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Entities;
using Kanban.Interfaces;
using Kanban.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers;   
public class TaskCardController : BaseApiController
{
    private ITaskCardRepository _repository;

    public TaskCardController(ITaskCardRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("createTask")]
    public async Task<ActionResult> CreateTask([FromBody]TaskCard entity)
    {
        _repository.Add(entity);
        await _repository.SaveAsync();
        return Ok();
    }

    [HttpGet("getAllTasks")]
    public async Task<ActionResult<IEnumerable<TaskCard>>> GetTaskList()
    {
        IEnumerable<TaskCard> tasks = await _repository.GetListAsync();
        return Ok(tasks);
    }
}