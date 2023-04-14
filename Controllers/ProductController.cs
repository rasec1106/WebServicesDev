using ApiProduct.DTOs;
using ApiProduct.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduct.Controllers
{
    [Route("api/[controller]")] // set the basepath; controller is an env variable to take the name of the Class
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private ResponseDto responseDto;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await productRepository.GetProducts();
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = productDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.Result = null;
                this.responseDto.DisplayMessage = ex.ToString();
            }            
            return responseDto;            
        }
    }
}
