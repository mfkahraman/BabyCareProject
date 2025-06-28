using AutoMapper;
using BabyCareProject.Entity.Dtos.OurProgramDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Mappings
{
    public class OurProgramMapping : Profile
    {
        public OurProgramMapping()
        {
            CreateMap<OurProgram, ResultOurProgramDto>().ReverseMap();
            CreateMap<OurProgram, UpdateOurProgramDto>().ReverseMap();
            CreateMap<OurProgram, CreateOurProgramDto>().ReverseMap();
            CreateMap<ResultOurProgramDto, UpdateOurProgramDto>().ReverseMap();

        }
    }
}
