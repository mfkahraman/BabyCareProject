using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.ProductDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _productCollection.FindOneAndDeleteAsync(x=> x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var values = await _productCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<UpdateProductDto> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find(x=> x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateProductDto>(product);
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == product.ProductId, product);
        }
    }
}
