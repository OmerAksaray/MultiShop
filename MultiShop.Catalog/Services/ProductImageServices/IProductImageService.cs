using MultiShop.Catalog.Dtos.ProductImagesDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {

        Task CreateProductImage(CreateProductImageDto createProductImage);

        Task UpdateProductImage(UpdateProductImageDto updateProductImage);

        Task DeleteProductImage(string id);

        
        Task<List<ResultProductImageDto>> GetAllProductImages();

        Task<GetByIdProductImageDto> GetByIdProductImage(string id);





    }
}
