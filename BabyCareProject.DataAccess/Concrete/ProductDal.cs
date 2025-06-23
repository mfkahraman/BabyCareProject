using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.DataAccess.Concrete
{
    public class ProductDal(IMongoCollection<Product> collection) : IProductDal
    {
        public async Task CreateAsync(Product entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await collection.AsQueryable().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await collection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            await collection.FindOneAndReplaceAsync(x => x.ProductId == entity.ProductId, entity);
        }
    }
}
