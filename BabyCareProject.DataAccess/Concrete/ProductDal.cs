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
    public class ProductDal : GenericRepository<Product>, IProductDal
    {
        public ProductDal(IMongoDatabase database, IDatabaseSettings settings) : base(database, settings.ProductCollectionName)
        {
        }
    }
}
