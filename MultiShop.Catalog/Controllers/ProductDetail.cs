using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.ProductDetailsServices;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetail : ControllerBase
    {

        private readonly IProdcutDetailsService _ProductDetailsService;
       
        public ProductDetail(IProdcutDetailsService ProductDetailsService)
        {
            _ProductDetailsService = ProductDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _ProductDetailsService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsById(string id)
        {
            var values = await _ProductDetailsService.GetByIdProductId(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            await _ProductDetailsService.CreateProductDetail(createProductDetailsDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetails(string id)
        {
            await _ProductDetailsService.DeleteProductDetail(id);

            return Ok("Ürün detayı Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetails)
        {
            await _ProductDetailsService.UpdateProductDetail(updateProductDetails);

            return Ok("Ürün detayı Başarıyla Güncellendi");
        }
    }
}
