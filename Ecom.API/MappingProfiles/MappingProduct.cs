﻿using AutoMapper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
namespace Ecom.API.MappingProfiles
{
    public class MappingProduct:Profile
    {
        public MappingProduct()
        {
             CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
