using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Entities;
using Kanban.Interfaces;
using Kanban.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers;   
public class TaskController : BaseApiController
{
    private ITaskCardRepository _repository;

    public TaskController(ITaskCardRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateTask([FromBody]TaskCard entity)
    {
        _repository.Add(entity);
        await _repository.SaveAsync();
        return Ok();
    }
}