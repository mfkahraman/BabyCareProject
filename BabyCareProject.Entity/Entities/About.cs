﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Entity.Entities
{
    public class About : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Feature1 { get; set; }
        public string? Feature2 { get; set; }
        public string? Feature3 { get; set; }
        public string? Feature4 { get; set; }
        public string? Feature5 { get; set; }
        public string? Feature6 { get; set; }
        public string? VideoUrl { get; set; }
    }
}
