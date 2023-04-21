using PathAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PathAPI.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly IMongoCollection<Workspace> _workspace;

    public WorkspaceRepository(IOptions<WorkspaceDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.WorkspaceConnectionString);
        var database = client.GetDatabase(settings.Value.WorkspaceDatabaseName);

        _workspace = database.GetCollection<Workspace>(settings.Value.WorkspaceCollectionName);
    }

    public async Task<IEnumerable<Workspace>> GetWorkspaces()
    {
        var allWorkspaces = await _workspace.FindAsync(workspace => true);
        return allWorkspaces.ToList();
    }

    public async Task<Workspace?> GetWorkspaceById(string workspaceId)
    {
        var workspaceFound = await _workspace.FindAsync<Workspace>(workspace => workspace.Id == workspaceId);
        return workspaceFound.FirstOrDefault();
    }

    public async Task<Workspace> CreateWorkspace(Workspace newWorkspace)
    {
        await _workspace.InsertOneAsync(newWorkspace);
        return newWorkspace;
    }

    public async Task DeleteWorkspaceById(string workspaceId)
    {
        await _workspace.DeleteOneAsync(workspace => workspace.Id == workspaceId);
    }

    public async Task<Workspace?> UpdateWorkspace(Workspace newWorkspace)
    {
        await _workspace.ReplaceOneAsync(workspace => workspace.Id == newWorkspace.Id, newWorkspace);
        return newWorkspace;
    }
}