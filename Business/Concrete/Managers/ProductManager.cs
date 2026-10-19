using AutoMapper;
using Business.Abstract.Services;
using Business.Concrete.Dtos;
using DataAccess.Abstract.UnitOfWorks;
using Entities.Concrete;
using Entities.Concrete.Exceptions;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            if (dto is not null)
            {
                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();
            }
            return new ProductDto();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id: id);
            if (product is null)
            {
                throw new NotFoundException();
            }
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ProductDto?>(await _unitOfWork.Products.GetByIdAsync(id));
        }

        public async Task UpdateAsync(ProductUpdateDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(dto.ProductId);

            if (product == null)
            {
                throw new KeyNotFoundException($"Girdiğiniz ID'ye ({dto.ProductId}) ait bir ürün bulunamadı.");
            }

            _mapper.Map(dto, product);

            _unitOfWork.Products.Update(product);

            // 4. Değişiklikleri Unit of Work vasıtasıyla tek bir işlemde (Transaction) veritabanına kaydediyoruz.
            await _unitOfWork.SaveChangesAsync();
        }
    }
}