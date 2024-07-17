using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImagesDtos;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImage : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImage(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productImageService.GetAllProductImages();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _productImageService.GetByIdProductImage(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductImageDto createImageProduct)
        {
            await _productImageService.CreateProductImage(createImageProduct);
            return Ok("Product başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productImageService.DeleteProductImage(id);

            return Ok("Product Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductImageDto updateImageProduct)
        {
            await _productImageService.UpdateProductImage(updateImageProduct);

            return Ok("Product Başarıyla Güncellendi");
        }
    }
}

