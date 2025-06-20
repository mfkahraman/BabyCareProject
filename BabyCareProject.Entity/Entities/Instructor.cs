﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BabyCareProject.DataAccess.Entities
{
    public class Instructor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
