using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Entity.Dtos.OurServiceDtos
{
    public class CreateOurServiceDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
