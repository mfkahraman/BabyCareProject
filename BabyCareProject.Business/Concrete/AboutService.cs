using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.AboutDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class AboutService : GenericService<About, CreateAboutDto, UpdateAboutDto, ResultAboutDto>, IAboutService
    {
        public AboutService(IGenericRepository<About> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
