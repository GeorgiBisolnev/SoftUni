using AutoMapper;
using ProductShop.DTOs.CategoriesProducts;
using ProductShop.DTOs.Categoryes;
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
            this.CreateMap<ImportCategoryDto, Category>();  
            this.CreateMap<ImportCategoryProductDto,CategoryProduct>();

            this.CreateMap<Product, ExportProductsDto>()
                .ForMember(d => d.SellerFullName,
                mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
        }
    }
}
