using PathAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PathAPI.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly IMongoCollection<T> _task;
    public TaskRepository(IOptions<TaskDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);

        _task = database.GetCollection<T>(settings.Value.CollectionName);
    }
    public async Task<IEnumerable<T>> GetAllTasks()
    {
        var allTasks = await _task.FindAsync(task => true);
        return allTasks.ToList();
    }

    public async Task<IEnumerable<T>> GetTasksByWorkspaceId(string workspaceId) 
    {
        var tasks = await _task.FindAsync<T>(x => x.WorkspaceId == workspaceId);
        return tasks.ToList();
    }

    public async Task<T?> GetTaskById(string taskId)
    {
        var taskFound = await _task.FindAsync<T>(task => task.Id == taskId);
        return taskFound.FirstOrDefault();
    }

    public async Task<T> CreateTask(T newTask, string workspaceId)
    {
        newTask.WorkspaceId = workspaceId;
        await _task.InsertOneAsync(newTask);
        return newTask;
    }

    public async Task<T> UpdateTask(T newTask)
    {
        await _task.ReplaceOneAsync(task => task.Id == newTask.Id, newTask);
        return newTask;
    }

    public async Task DeleteTaskById(string taskId)
    {
        await _task.DeleteOneAsync(task => task.Id == taskId);
    }
}