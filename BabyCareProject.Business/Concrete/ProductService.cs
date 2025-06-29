﻿using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.ProductDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class ProductService : GenericService<Product, CreateProductDto, UpdateProductDto, ResultProductDto>, IProductService
    {
        public ProductService(IGenericRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
