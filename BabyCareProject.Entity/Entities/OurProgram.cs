using BabyCareProject.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class OurProgram : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string InstructorId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    public int SessionCount { get; set; }
    public int DurationMinute { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}
