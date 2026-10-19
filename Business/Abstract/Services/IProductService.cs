using Business.Concrete.Dtos;

namespace Business.Abstract.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductCreateDto dto);
        Task UpdateAsync(ProductUpdateDto dto);
        Task DeleteAsync(int id);
    }
}