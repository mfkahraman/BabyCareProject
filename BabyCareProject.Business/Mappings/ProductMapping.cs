using AutoMapper;
using BabyCareProject.Entity.Dtos.ProductDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<ResultProductDto, UpdateProductDto>().ReverseMap();
        }
    }
}
