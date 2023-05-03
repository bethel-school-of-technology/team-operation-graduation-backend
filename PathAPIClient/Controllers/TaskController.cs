using PathAPI.Models;
using PathAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PathAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    private readonly ITaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _taskRepository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> GetTasks()
    {
        return Ok(await _taskRepository.GetAllTasks());
    }

    [HttpGet]
    [Route("{workspaceId}")]
    public async Task<ActionResult<IEnumerable<T>>> GetTasksByWorkspaceId(string workspaceId)
    {
        return Ok(await _taskRepository.GetTasksByWorkspaceId(workspaceId));
    }

    [HttpGet]
    [Route("{taskId}")]
    public async Task<ActionResult<T>> GetTaskById(string taskId) 
    {
        var task = _taskRepository.GetTaskById(taskId);
        if(task == null) {
            return NotFound();
        }
        return Ok(await task);
    }

    [HttpPost]
    public async Task<ActionResult<T>> CreateTask(T task)
    {
        if(!ModelState.IsValid || task == null) {
            return BadRequest();
        }
        var newTask = _taskRepository.CreateTask(task);
        return Created(nameof (GetTaskById), await newTask);
    }

    [HttpPut]
    [Route("{taskId}")]
    public async Task<ActionResult<T>> UpdateTask(T task)
    {
        if(!ModelState.IsValid || task == null) {
            return BadRequest();
        }
        return Ok(await _taskRepository.UpdateTask(task));
    }

    [HttpDelete]
    [Route("{taskId}")]
    public async Task<ActionResult<IEnumerable<T>>> DeleteCoffee(string taskId) 
    {
        await _taskRepository.DeleteTaskById(taskId); 
        return NoContent();
    }
}