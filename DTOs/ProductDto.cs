using System;
namespace ApiProduct.DTOs
{
    // We use this class to "transform" the object. DTO=Data Transformation Object
    // e.g. we expose only some attributes of the model (we could also add some calculated properties to show) 
    // in this case we don't show the price
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
