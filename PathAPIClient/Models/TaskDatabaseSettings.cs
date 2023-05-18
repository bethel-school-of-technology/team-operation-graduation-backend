namespace PathAPI.Models;

public class TaskDatabaseSettings
{
    public string? CollectionName { get; set; } = null!;
    public string? ConnectionString { get; set; } = null!;
    public string? DatabaseName { get; set; } = null!;
}