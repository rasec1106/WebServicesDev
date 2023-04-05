using System;
using ApiProduct.DTOs;
namespace ApiProduct.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int productId);
        public Task<ProductDto> CreateProduct(ProductDto productDto);
        public Task<ProductDto> UpdateProduct(ProductDto productDto);
        public Task<bool> DeleteProduct(int productId);
    }
}
