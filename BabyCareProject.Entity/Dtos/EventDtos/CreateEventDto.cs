using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Entity.Dtos.EventDtos
{
    public class CreateEventDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string Date { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
        public string StartTime { get; set; } = TimeSpan.Zero.ToString(@"hh\:mm");
        public string EndTime { get; set; } = TimeSpan.Zero.ToString(@"hh\:mm");
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }

}
