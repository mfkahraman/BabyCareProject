using BabyCareProject.Entity.Dtos.ProductDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IProductService : IGenericService<CreateProductDto, UpdateProductDto, ResultProductDto, Product>
    {
    }
}
