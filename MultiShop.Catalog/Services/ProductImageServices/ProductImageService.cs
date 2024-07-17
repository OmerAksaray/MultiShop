using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImagesDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            
            var client=new MongoClient(databaseSettings.ConnectionString);
            var database=client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImagesCollectionName);
            _mapper = mapper;
        }




        public async Task CreateProductImage(CreateProductImageDto createProductImage)
        {

            var value=_mapper.Map<ProductImage>(createProductImage);

            await _productImageCollection.InsertOneAsync(value);

        }

        public async Task DeleteProductImage(string id)
        {
            await  _productImageCollection.DeleteOneAsync(x=>x.ProductImageId == id);          
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImages()
        {
            var value = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(value);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImage(string id)
        {
            var value= await _productImageCollection.Find<ProductImage>(x=>x.ProductImageId==id).FirstOrDefaultAsync();
           
            return  _mapper.Map<GetByIdProductImageDto>(value);   
        }

        public async Task UpdateProductImage(UpdateProductImageDto updateProductImage)
        {
          var value= _mapper.Map<ProductImage>(updateProductImage);
          await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImage.ProductImageId,value);
        }
    }
}
