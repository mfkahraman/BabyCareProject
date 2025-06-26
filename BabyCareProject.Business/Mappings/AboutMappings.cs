using AutoMapper;
using BabyCareProject.Entity.Dtos.AboutDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Mappings
{
    public class AboutMappings : Profile
    {
        public AboutMappings()
        {
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>();
            CreateMap<UpdateAboutDto, ResultAboutDto>().ReverseMap();
        }
    }
}
