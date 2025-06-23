using AutoMapper;
using BabyCareProject.Entity.Dtos.InstructorDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BabyCareProject.Business.Mappings
{
    public class InstructorMapping : Profile
    {
        public InstructorMapping()
        {
            CreateMap<Instructor, ResultInstructorDto>();
            CreateMap<Instructor, CreateInstructorDto>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorDto>().ReverseMap();
            CreateMap<ResultInstructorDto, UpdateInstructorDto>();
        }
    }
}
