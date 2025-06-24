using AutoMapper;
using BabyCareProject.Entity.Dtos.BannerDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Mappings
{
    public class BannerMappings : Profile
    {
        public BannerMappings()
        {
            CreateMap<Banner, ResultBannerDto>();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();
        }
    }
}
