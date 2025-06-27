using AutoMapper;
using BabyCareProject.Entity.Dtos.OurServiceDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Mappings
{
    public class OurServiceMappings : Profile
    {
        public OurServiceMappings()
        {
            CreateMap<OurService, CreateOurServiceDto>().ReverseMap();
            CreateMap<OurService, UpdateOurServiceDto>().ReverseMap();
            CreateMap<OurService, ResultOurServiceDto>();
            CreateMap<ResultOurServiceDto, UpdateOurServiceDto>().ReverseMap();
        }
    }
}
