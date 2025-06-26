using BabyCareProject.Entity.Dtos.AboutDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IAboutService : IGenericService<CreateAboutDto,UpdateAboutDto,ResultAboutDto,About>
    {
    }
}
