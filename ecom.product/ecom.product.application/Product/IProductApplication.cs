using ecom.product.domain.Product;

namespace ecom.product.application.ProductApp
{
    public interface IProductApplication
    {
        Task<ecom.product.domain.Product.Product> GetAsync(string id);
        Task<IEnumerable<ecom.product.domain.Product.Product>> ListAsync();
        Task<string> AddAsync(Product product);
        Task<int> UpdateQuantityAsync(string id, int quantity);
        
    }
}
