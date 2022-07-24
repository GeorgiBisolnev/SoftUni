using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
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
            //
            //Console.WriteLine("Let's go ...");

            // Problem 001
            //string jsonInput1 = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, jsonInput1));
            //Problem 002
            //string jsonInput2 = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, jsonInput2));

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

    }
    
}