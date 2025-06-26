using BabyCareProject.Entity.Dtos.InstructorDtos;
using BabyCareProject.Entity.Dtos.ProductDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IInstructorService : IGenericService<CreateInstructorDto, UpdateInstructorDto, ResultInstructorDto, Instructor>
    {
    }
}
