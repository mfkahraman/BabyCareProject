using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCareProject.Entity.Entities
{
    public class Event : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");

        [BsonElement("StartTime")]
        public string StartTime { get; set; } = TimeSpan.Zero.ToString(@"hh\:mm");

        [BsonElement("EndTime")]
        public string EndTime { get; set; } = TimeSpan.Zero.ToString(@"hh\:mm");

        public string? ImageUrl { get; set; }
    }

}
