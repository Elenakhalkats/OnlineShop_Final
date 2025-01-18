﻿using AutoMapper;
using OnlineShop.Application.Models.Customers;
using OnlineShop.Application.Models.Products;
using OnlineShop.Domain.Entites;

namespace OnlineShop.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDetailsViewModel>();
        CreateMap<Product, ProductEditViewModel>();
        CreateMap<Product, ProductListViewModel>();

        CreateMap<Customer, CustomerListViewModel>();
    }
}
