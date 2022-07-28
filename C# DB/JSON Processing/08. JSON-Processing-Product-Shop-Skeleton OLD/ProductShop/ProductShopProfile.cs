using AutoMapper;
using ProductShop.DTOs.CategoriesProducts;
using ProductShop.DTOs.Categoryes;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;
using System.Linq;

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

            //Inner DTO
            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
            //Outer DTO
            this.CreateMap<User, ExportUsersWithSoldProductsDto>()
                .ForMember(d => d.FirstName, mo => mo.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, mo => mo.MapFrom(s => s.LastName))
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p=>p.BuyerId.HasValue)));
        }
    }
}
