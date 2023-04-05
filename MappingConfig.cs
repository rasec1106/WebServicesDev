using System;
using ApiProduct.DTOs;
using ApiProduct.Models;
using AutoMapper;
namespace ApiProduct
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // it maps the two classes by its fields. If they have a different name we can use a decorator (annotation)
                // when i give you a ProductDto object it transforms it into a Product object
                config.CreateMap<ProductDto, Product>();
                // and viceversa
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
