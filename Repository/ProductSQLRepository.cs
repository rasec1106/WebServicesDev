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

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            // transform it into Product
            Product product = this.mapper.Map<Product>(productDto);
            // add in memory
            this.dbContext.Add(product);
            
            // save in database
            await this.dbContext.SaveChangesAsync();
            /*
             * When we make the save, automatically the framework assigns the id to that variable
             */
            return this.mapper.Map<ProductDto>(product);
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

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            // We could use "var" ==> this reserved word is used to infere types ... the compiler guesses which type of variable it'll be
            // var product = this.mapper.Map<Product>(productDto);
            Product product = this.mapper.Map<Product>(productDto);
            this.dbContext.Update(product);
            await this.dbContext.SaveChangesAsync();
            return productDto;
            //return this.mapper.Map<ProductDto>(product); // could be also this way, but its less effective
        }
    }
}
