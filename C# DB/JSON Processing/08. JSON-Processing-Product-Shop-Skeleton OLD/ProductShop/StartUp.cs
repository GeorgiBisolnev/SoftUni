using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine("Let's go ...");
            string jsonInput = File.ReadAllText("../../../Datasets/users.json");

            Console.WriteLine(ImportUsers(context, jsonInput));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var str = new StringBuilder();

            ImportUserDto[] userDTO = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (ImportUserDto uDto in userDTO)
            {
                User user = mapper.Map<User>(uDto);

                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
    }
    
}