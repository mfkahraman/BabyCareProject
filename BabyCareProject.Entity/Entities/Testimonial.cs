using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.Entity.Entities
{
    public class Testimonial : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        public string? FullName { get; set; }
        public string? Title { get; set; }   
        public string? Comment { get; set; } 
        public int Rating { get; set; } = 5; 
        public string? ImageUrl { get; set; }
    }
}
