using AutoMapper;
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
    public class ProductService(IProductDal productDal,
                                IMapper mapper) : IProductService
    {
        public async Task CreateAsync(CreateProductDto dto)
        {
            var entity = mapper.Map<Product>(dto);
            await productDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await productDal.DeleteAsync(id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var entities = await productDal.GetAllAsync();
            return mapper.Map<List<ResultProductDto>>(entities);
        }

        public async Task<ResultProductDto> GetByIdAsync(string id)
        {
            var entity = productDal.GetByIdAsync(id);
            return await mapper.Map<Task<ResultProductDto>>(entity);
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var entity = mapper.Map<Product>(dto);
            await productDal.UpdateAsync(entity);
        }
    }
}
