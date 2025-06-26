using BabyCareProject.Entity.Dtos.BannerDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IBannerService : IGenericService<CreateBannerDto, UpdateBannerDto, ResultBannerDto, Banner>
    {
    }
}
