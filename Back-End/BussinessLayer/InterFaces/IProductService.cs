using ApiContract.Dtos;
using ApiContracts;

namespace BussinessLayer.InterFaces
{
    public interface IProductService
    {
        Task<GResponse<IEnumerable<ProductDto>>> GetAllProductsAsync();
        Task<GResponse<IEnumerable<ProductDto>>> GetAllProductsBySellerIfAsync(int sellerid);
        Task<GResponse<ProductDto>> GetProductByIdAsync(int id);
        Task<GResponse<ProductDto>> CreateProductAsync(CreateProductDto dto);
        Task<GResponse<string>> UpdateProductAsync(UpdateProductDto dto);
        Task<GResponse<string>> DeleteProductAsync(int id);
    }
}
