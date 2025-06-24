using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Entity.Dtos.BannerDtos
{
    public class UpdateBannerDto
    {
        public string Id { get; set; }
        public string Slogan { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
