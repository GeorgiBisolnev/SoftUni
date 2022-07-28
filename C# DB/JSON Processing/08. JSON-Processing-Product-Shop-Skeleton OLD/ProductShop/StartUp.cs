using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.CategoriesProducts;
using ProductShop.DTOs.Categoryes;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine("Let's go ...");

            ////Problem 001
            //string jsonInput1 = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, jsonInput1));
            ////Problem 002
            //string jsonInput2 = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, jsonInput2));
            ////Problem 003
            //string jsonInput3 = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, jsonInput3));
            ////Problem 004
            //string jsonInput4 = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, jsonInput4));

            Console.WriteLine(GetUsersWithProducts(context));

        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }

        //Problem 001
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var str = new StringBuilder();

            ImportUserDto[] userDTO = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (ImportUserDto uDto in userDTO)
            {
                User user = Mapper.Map<User>(uDto);

                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        // Problem 002
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productDTOs = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> products = new List<Product>();

            foreach (var pro in productDTOs)
            {
                if (!IsValid(pro))
                {
                    continue;
                }
                Product product = Mapper.Map<Product>(pro);

                products.Add(product);
            }

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //problem 003
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categoryesDto = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> categoryes = new List<Category>();

            foreach (ImportCategoryDto dto in categoryesDto)
            {
                if (!IsValid(dto))
                {
                    continue;
                }

                Category category = Mapper.Map<Category>(dto);
                categoryes.Add(category);
            }

            context.Categories.AddRange(categoryes);
            context.SaveChanges();

            return $"Successfully imported {categoryes.Count}";
        }

        //Problem 004
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] dtos = JsonConvert
                .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryesProducts = new List<CategoryProduct>();

            foreach (ImportCategoryProductDto dto in dtos)
            {
                if (!IsValid(dto))
                {
                    continue;
                }
                CategoryProduct categoryProductToAdd = Mapper.Map<CategoryProduct>(dto);
                validCategoryesProducts.Add(categoryProductToAdd);
            }

            context.CategoryProducts.AddRange(validCategoryesProducts);
            context.SaveChanges();
            return $"Successfully imported {validCategoryesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsDto[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductsDto>()
                .ToArray();  
            
            return JsonConvert.SerializeObject(products);

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(s => s.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                //.ProjectTo<ExportUsersWithSoldProductsDto>()
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(p => p.BuyerId.HasValue).Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .ToArray();

            return JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryesByPC = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):F2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .ToArray()
                .OrderByDescending(c=>c.productsCount);

            return JsonConvert  .SerializeObject(categoryesByPC, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(p => p.BuyerId.HasValue).Count(),
                        products = u.ProductsSold.Where(p => p.BuyerId.HasValue).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .ToList()

                    }

                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();               
                

            var result = new
            {
                usersCount = users.Count(),
                users = users
            };

            return JsonConvert.SerializeObject(result, GetJsonSettings());
        }

        private static JsonSerializerSettings GetJsonSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
    
}