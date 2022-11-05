using ecom.order.Extensions;

namespace ecom.order.infrastructure.Product
{
    public class ProductService : IProductService
    {
        private readonly HttpClient client;
        public ProductService(HttpClient client)
        {
            this.client = client;            
        }
        public async Task<int> UpdateProductQuantity(string id, int quantity)
        {  
            
            var response = await client.PostAsJson<string>($"product/product/{id}/updatequnatity/{quantity}", string.Empty);            
            var productPrice = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return Convert.ToInt32(productPrice);
        }
    }
}
