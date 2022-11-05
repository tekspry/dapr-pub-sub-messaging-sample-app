using ecom.product.database.ProductDB;
using ecom.product.domain.Product;
using Microsoft.Extensions.Logging;

namespace ecom.product.application.ProductApp
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
      
        private readonly ILogger<ProductApplication> logger;
       
        public ProductApplication(IProductRepository productRepository, ILogger<ProductApplication> logger)
        {
            _productRepository = productRepository;            
            this.logger = logger;
        }

        public async Task<domain.Product.Product> GetAsync(string id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<IEnumerable<domain.Product.Product>> ListAsync()
        {           
            return await _productRepository.GetProducts();
        }

        public async Task<string> AddAsync(Product product)
        {   
            return await _productRepository.CreateProduct(product);
        }

        public async Task<int> UpdateQuantityAsync(string id, int quantity) 
        {
            var product = await GetAsync(id);
            product.Quantity -= quantity;
            return await _productRepository.UpdateProduct(product);
        }


    }
}
