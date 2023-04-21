using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PathAPI.Models;

public class Workspace {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 
    [Required]
    [BsonElement("Name")]
    public string? Name { get; set; }
    [Required]
    [BsonElement("Description")]
    public string? Description { get; set; }
    [BsonElement("Goals")]
    public string[]? Goals { get; set; }
    [BsonElement("TaskList")]
    public T[]? TaskList { get; set; }
}