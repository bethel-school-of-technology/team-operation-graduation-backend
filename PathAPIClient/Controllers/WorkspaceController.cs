using PathAPI.Models;
using PathAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PathAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class WorkspaceController : ControllerBase
{
    private readonly ILogger<WorkspaceController> _logger;

    private readonly IWorkspaceRepository _workspaceRepository;

    public WorkspaceController(ILogger<WorkspaceController> logger, IWorkspaceRepository repository)
    {
        _logger = logger;
        _workspaceRepository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workspace>>> GetWorkspaces()
    {
        return Ok(await _workspaceRepository.GetWorkspaces());
    }

    [HttpGet]
    [Route("{workspaceId}")]
    public async Task<ActionResult<Workspace>> GetWorkspaceById(string workspaceId) 
    {
        var workspace = _workspaceRepository.GetWorkspaceById(workspaceId);
        if(workspace == null) {
            return NotFound();
        }
        return Ok(await workspace);
    }

    [HttpPost]
    public async Task<ActionResult<Workspace>> CreateWorkspace(Workspace workspace)
    {
        if(!ModelState.IsValid || workspace == null) {
            return BadRequest();
        }
        var newWorkspace = _workspaceRepository.CreateWorkspace(workspace);
        return Created(nameof (GetWorkspaceById), await newWorkspace);
    }

    [HttpPut]
    [Route("{workspaceId}")]
    public async Task<ActionResult<Workspace>> UpdateWorkspace(Workspace workspace)
    {
        if(!ModelState.IsValid || workspace == null) {
            return BadRequest();
        }
        return Ok(await _workspaceRepository.UpdateWorkspace(workspace));
    }

    [HttpDelete]
    [Route("{workspaceId}")]
    public async Task<ActionResult<IEnumerable<Workspace>>> DeleteCoffee(string workspaceId) 
    {
        await _workspaceRepository.DeleteWorkspaceById(workspaceId); 
        return NoContent();
    }
}