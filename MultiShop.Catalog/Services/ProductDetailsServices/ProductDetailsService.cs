using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Services.ProductDetailsServices
{
    public class ProductDetailsService: IProdcutDetailsService
    {
        private IMongoCollection<ProductDetails> _productDetailsCollection;

        private IMapper _mapper;

        public ProductDetailsService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database= client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailsCollection=database.GetCollection<ProductDetails>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetail(CreateProductDetailDto createProductDetail)
        {
           var value= _mapper.Map<ProductDetails>(createProductDetail);

            await _productDetailsCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetail(string id)
        {

           await _productDetailsCollection.DeleteOneAsync(x=>x.ProductDetailID==id);

            
        }

        public async Task<List<ResultProductDetailDto>> GetAllAsync()
        {
            var values = await _productDetailsCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductId(string id)
        {
            var values= await _productDetailsCollection.Find<ProductDetails>(x =>x.ProductDetailID == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetail(UpdateProductDetailDto productDetail)
        {
            var values = _mapper.Map<ProductDetails>(productDetail);

            await _productDetailsCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == productDetail.ProductDetailID, values);
        }
    }
}
