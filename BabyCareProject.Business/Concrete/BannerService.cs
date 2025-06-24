using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.BannerDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class BannerService : GenericService<Banner, CreateBannerDto, UpdateBannerDto, ResultBannerDto>, IBannerService
    {
        public BannerService(IGenericRepository<Banner> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
