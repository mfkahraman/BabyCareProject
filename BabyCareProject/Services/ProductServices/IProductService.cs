using BabyCareProject.Dtos.ProductDtos;

namespace BabyCareProject.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task<ResultProductDto> GetByIdAsync(string id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(UpdateProductDto dto);
        Task DeleteAsync(string id);
    }
}
