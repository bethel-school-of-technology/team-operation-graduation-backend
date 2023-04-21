using PathAPI.Models;

namespace PathAPI.Repositories;

public interface IWorkspaceRepository
{
    Task<IEnumerable<Workspace>> GetWorkspaces();
    Task<Workspace?> GetWorkspaceById(string workspaceId);
    Task<Workspace> CreateWorkspace(Workspace newWorkspace);
    Task<Workspace?> UpdateWorkspace(Workspace newWorkspace);
    Task DeleteWorkspaceById(string workspaceId);
}