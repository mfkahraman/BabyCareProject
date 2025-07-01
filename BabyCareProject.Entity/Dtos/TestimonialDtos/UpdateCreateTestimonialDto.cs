﻿using Microsoft.AspNetCore.Http;

namespace BabyCareProject.Entity.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
