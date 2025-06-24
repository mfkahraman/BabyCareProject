using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.InstructorDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class InstructorService : GenericService<Instructor, CreateInstructorDto, UpdateInstructorDto, ResultInstructorDto>, IInstructorService
    {
        public InstructorService(IGenericRepository<Instructor> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
