using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client=new MongoClient(databaseSettings.ConnectionString);
            var database=client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection=database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values= await _productCollection.Find(x=>true).ToListAsync();

            return _mapper.Map<List<ResultProductDto>>(values); 

        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values= _mapper.Map<Product>(createProductDto);

            await _productCollection.InsertOneAsync(values);

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value= _mapper.Map<Product>(updateProductDto);

            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductID==id);
        }

        public async Task<GetByIdProductDto> GetProductByIdAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            
            return _mapper.Map<GetByIdProductDto>(values);
               
        }
    }
}
