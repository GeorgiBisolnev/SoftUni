using AutoMapper;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
        }
    }
}
