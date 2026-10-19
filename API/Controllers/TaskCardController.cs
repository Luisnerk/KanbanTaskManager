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
    public async Task<ActionResult> CreateTask([FromBody]TaskCard entity)
    {
        _repository.Add(entity);
        await _repository.SaveAsync();
        return Ok();
    }

    [HttpGet("getAllTasks")]
    public async Task<ActionResult<IEnumerable<TaskCardDto>>> GetTaskList()
    {
        IEnumerable<TaskCard> tasks = await _repository.GetListAsync();
        IEnumerable<TaskCardDto> tasksDto = _mapper.Map<IEnumerable<TaskCardDto>>(tasks);
        return Ok(tasksDto);
    }

    [HttpPut("updateTask")]
    public async Task<ActionResult> UpdateTask(TaskCardDto taskCardDto)
    {
        if (taskCardDto == null)
        {
            return BadRequest("Objeto inválido");
        }
        try
        {
            TaskCard taskCard = _mapper.Map<TaskCard>(taskCardDto);
            _repository.UpdateItem(taskCard);
            await _repository.SaveAsync();
            return Ok();
        } catch (Exception error)
        {
            return StatusCode(500, "Error al procesar la solicitud");
        }
    }

    [HttpDelete("deleteTask")]
    public async Task<ActionResult> DeleteTask([FromBody]TaskCardDto taskCardDto)
    {
        TaskCard taskCard = _mapper.Map<TaskCard>(taskCardDto);
        _repository.DeleteItem(taskCard);
        await _repository.SaveAsync();
        return Ok();
    }
}