using API_Product.Models;
using API_Product.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API_Product.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productRepository.GetProducts();
        }
        [HttpGet]
        [Route("/GetProductById/{id}")]
        public async Task<Product> GetCustomerById(int id)
        {
            return await productRepository.GetProductById(id);
        }

        [HttpPost]
        [Route("/CreateProduct")]
        public async Task<Product> CreateCustomer(Product product)
        {
            return await productRepository.CreateProduct(product);
        }

        [HttpPut]
        [Route("/UpdateProduct")]
        public async Task<Product> UpdateCustomer(Product product)
        {
            return await productRepository.UpdateProduct(product);
        }


        [HttpDelete]
        [Route("/DeleteProduct")]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await productRepository.DeleteProduct(id);
        }
    }
}
