using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.OurProgramDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class OurProgramService : GenericService<OurProgram, CreateOurProgramDto, UpdateOurProgramDto, ResultOurProgramDto>, IOurProgramService
    {
        public OurProgramService(IGenericRepository<OurProgram> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
