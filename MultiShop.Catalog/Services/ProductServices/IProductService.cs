using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {

        Task <List<ResultProductDto>> GetAllProductAsync();

        Task CreateProductAsync(CreateProductDto createProductDto);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);

        Task<GetByIdProductDto> GetProductByIdAsync(string id);
    }
}
