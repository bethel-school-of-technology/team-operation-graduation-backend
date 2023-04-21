using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PathAPI.Models;

public class User {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    [BsonElement("Username")]
    public string? Username { get; set; }
    [Required]
    [BsonElement("Password")]
    public string? Password { get; set; }
    [Required]
    [BsonElement("Name")]
    public string? Name { get; set; }
    [Required]
    [BsonElement("Email")]
    public string? Email { get; set; }
}