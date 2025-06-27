using BabyCareProject.Entity.Dtos.OurServiceDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IOurServiceService : IGenericService<CreateOurServiceDto,UpdateOurServiceDto,ResultOurServiceDto, OurService>
    {
    }
}
