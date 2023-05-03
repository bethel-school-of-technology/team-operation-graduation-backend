using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PathAPI.Models;

public class T
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [BsonElement("WorkspaceId")]
    public string? WorkspaceId { get; set; }
    [Required]
    [BsonElement("Name")]
    public string? Name { get; set; }
    [Required]
    [BsonElement("Description")]
    public string? Description { get; set; }
    [BsonElement("Notes")]
    public string[]? Notes { get; set; }
    [BsonElement("Completed")]
    public bool Completed { get; set; } 
}