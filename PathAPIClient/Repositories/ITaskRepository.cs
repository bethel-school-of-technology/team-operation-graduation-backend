using PathAPI.Models;

namespace PathAPI.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<T>> GetAllTasks();
    Task<T?> GetTaskById(string taskId);
    Task<T> CreateTask(T newTask);
    Task<T> UpdateTask(T newTask);
    Task DeleteTaskById(string taskId);
}