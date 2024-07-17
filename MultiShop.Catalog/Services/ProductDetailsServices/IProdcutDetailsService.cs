using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Services.ProductDetailsServices
{
    public interface IProdcutDetailsService
    {
        Task<List<ResultProductDetailDto>> GetAllAsync();


        Task UpdateProductDetail(UpdateProductDetailDto productDetail);

        Task DeleteProductDetail(string id);

        Task CreateProductDetail(CreateProductDetailDto createProductDetail);


        Task<GetByIdProductDetailDto> GetByIdProductId(string id);
    }
}
