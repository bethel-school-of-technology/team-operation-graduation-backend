namespace PathAPI.Models;

public class WorkspaceDatabaseSettings
{
    public string? CollectionName { get; set; } = null!;
    public string? ConnectionString { get; set; } = null!;
    public string? DatabaseName { get; set; } = null!;
}