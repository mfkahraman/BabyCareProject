using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.OurServiceDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class OurServiceService : GenericService<OurService, CreateOurServiceDto, UpdateOurServiceDto, ResultOurServiceDto>, IOurServiceService
    {
        public OurServiceService(IGenericRepository<OurService> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
