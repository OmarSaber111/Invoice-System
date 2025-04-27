using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            var data = await _repo.GetAllProductsAsync();
            var result = _mapper.Map<IEnumerable<ProductDto>>(data);
            return GResponse<IEnumerable<ProductDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            var data = await _repo.GetProductByIdAsync(id);
            if (data == null)
                return GResponse<ProductDto>.CreateFailure("404", "Product not found");

            return GResponse<ProductDto>.CreateSuccess(_mapper.Map<ProductDto>(data));
        }

        public async Task<GResponse<ProductDto>> CreateProductAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repo.InsertAsync(entity);
            await _repo.Commit();

            return GResponse<ProductDto>.CreateSuccess(_mapper.Map<ProductDto>(entity));
        }

        public async Task<GResponse<string>> UpdateProductAsync(UpdateProductDto dto)
        {
            var existing = await _repo.GetProductByIdAsync(dto.Id);
            if (existing == null)
                return GResponse<string>.CreateFailure("404", "Product not found");

            _mapper.Map(dto, existing);
            await _repo.Commit();

            return GResponse<string>.CreateSuccess("Updated");
        }

        public async Task<GResponse<String>> DeleteProductAsync(int id)
        {
            var existing = await _repo.GetProductByIdAsync(id);
            if (existing == null)
                return GResponse<string>.CreateFailure("404", "Product not found");

            _repo.Delete(existing);
            await _repo.Commit();

            return GResponse<string>.CreateSuccess("Deleted successfully");
        }

        public async Task<GResponse<IEnumerable<ProductDto>>> GetAllProductsBySellerIfAsync(int sellerid)
        {
            var products = await _repo.GetBySellerIdAsync(sellerid);
            if (products == null)
                return GResponse<IEnumerable<ProductDto>>.CreateFailure("404", "this seller doesn't have any product");
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return GResponse<IEnumerable<ProductDto>>.CreateSuccess(result);

        }
    }

}
