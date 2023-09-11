using API_Product.Models;

namespace API_Product.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProductById(int ProductId);
        public Task<Product> CreateProduct (Product product);
        public Task<Product> UpdateProduct (Product product);
        public Task<bool> DeleteProduct (int ProductId);
    }
}
