using ApiProduct.DbContexts;
using ApiProduct.DTOs;
using ApiProduct.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProduct.Repository
{
    public class ProductSQLRepository : IProductRepository
    {
        private AppDbContext dbContext;
        private IMapper mapper;
        // We will use dependency injection passing as parameters with the same name
        public ProductSQLRepository(AppDbContext dbContext, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product? product = await this.dbContext.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                // We remove the product from RAM memory
                this.dbContext.Products.Remove(product);
                // To persist the changes we need to save the changes
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product? product = await this.dbContext.Products.Where(product => product.ProductId == productId).FirstOrDefaultAsync();
            return this.mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await this.dbContext.Products.ToListAsync();
            return this.mapper.Map<List<ProductDto>>(products);
        }

        public Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
