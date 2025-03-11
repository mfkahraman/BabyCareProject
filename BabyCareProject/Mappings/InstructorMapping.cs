using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.InstructorDtos;

namespace BabyCareProject.Mappings
{
    public class InstructorMapping : Profile
    {
        public InstructorMapping()
        {
            CreateMap<Instructor, ResultInstructorDto>().ReverseMap();
            CreateMap<Instructor, CreateInstructorDto>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorDto>().ReverseMap();
        }
    }
}
