using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban.Dtos;
using Kanban.Entities;
using Kanban.Interfaces;
using Kanban.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers;   
public class TaskCardController : BaseApiController
{
    private ITaskCardRepository _repository;

    public TaskCardController(ITaskCardRepository repository, IMapper mapper) : base(mapper)
    {
        _repository = repository;
    }

    [HttpPost("createTask")]
    public async Task<ActionResult> createTask([FromBody]TaskCard entity)
    {
        _repository.add(entity);
        await _repository.saveAsync();
        return Ok();
    }

    [HttpGet("getAllTasks")]
    public async Task<ActionResult<IEnumerable<TaskCardDto>>> getTaskList()
    {
        IEnumerable<TaskCard> tasks = await _repository.getListAsync();
        IEnumerable<TaskCardDto> tasksDto = _mapper.Map<IEnumerable<TaskCardDto>>(tasks);
        return Ok(tasksDto);
    }

    [HttpPut("updateTask")]
    public async Task<ActionResult> updateTask(TaskCardDto taskCardDto)
    {
        if (taskCardDto == null)
        {
            return BadRequest("Objeto inválido");
        }
        try
        {
            TaskCard taskCard = _mapper.Map<TaskCard>(taskCardDto);
            _repository.updateItem(taskCard);
            await _repository.saveAsync();
            return Ok();
        } catch (Exception error)
        {
            return StatusCode(500, "Error al procesar la solicitud");
        }
    }
}