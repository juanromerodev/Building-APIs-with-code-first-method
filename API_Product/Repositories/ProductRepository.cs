

using API_Product.DbContexts;
using API_Product.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //Crear productos con Entity Frmwork
        public async Task<Product> CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        //Actualizar productos con Entity Frmwork
        public async Task<Product> UpdateProduct(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        //Eliminar productos con Entity Frmwork
        public async Task<bool> DeleteProduct(int ProductId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p =>p.ProductId == ProductId);
            if (product == null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }
        //Buscar productos con Entity Frmwork
        public async Task<Product> GetProductById(int ProductId)
        {
            var product = await dbContext.Products.Where(p => p.ProductId == ProductId).FirstOrDefaultAsync();
            return product;
        }
        //Listar productos con Entity Frmwork
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

    }
}
