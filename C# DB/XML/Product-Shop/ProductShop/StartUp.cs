using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbcontext = new ProductShopContext();

            //dbcontext.Database.EnsureDeleted();
            //dbcontext.Database.EnsureCreated();
            //System.Console.WriteLine("New Database created");

            //string inputXML = File.ReadAllText("../../../Datasets/users.xml");
            //System.Console.WriteLine(ImportUsers(dbcontext, inputXML));
            //string inputXML2 = File.ReadAllText("../../../Datasets/products.xml");
            //System.Console.WriteLine(ImportProducts(dbcontext, inputXML2));
            //string inputXML3 = File.ReadAllText("../../../Datasets/categories.xml");
            //System.Console.WriteLine(ImportCategories(dbcontext,inputXML3));
            //string inputXML4 = File.ReadAllText("../../../Datasets/categories-products.xml");
            //System.Console.WriteLine(ImportCategoryProducts(dbcontext, inputXML4));

            System.Console.WriteLine(GetSoldProducts(dbcontext));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersImportDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            UsersImportDto[] usersDto = (UsersImportDto[])xmlSerializer.Deserialize(reader);

            List<User> validUsers = new List<User>();

            foreach (var usersd in usersDto)
            {
                User user = new User()
                {
                    FirstName = usersd.FirstName,
                    LastName = usersd.LastName,
                    Age = usersd.Age,
                };

                validUsers.Add(user);
            }

            context.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsImportDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ProductsImportDto[] productsDto = (ProductsImportDto[])xmlSerializer.Deserialize(reader);

            List<Product> validProducts = new List<Product>();

            //context vaildBuyers = context.Users

            foreach (var p in productsDto)
            {
                Product product = new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId,
                };
                
                validProducts.Add(product);
            }

            context.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }


        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesImportDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            CategoriesImportDto[] categoryDtos = (CategoriesImportDto[])xmlSerializer.Deserialize(reader);

            List<Category> validCategories = new List<Category>();

            //context vaildBuyers = context.Users

            foreach (var p in categoryDtos)
            {
                Category category = new Category();
                category.Name = p.Name;

                validCategories.Add(category);
            }

            context.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCatProdDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportCatProdDto[] cpDtos = (ImportCatProdDto[])xmlSerializer.Deserialize(reader);

            List<CategoryProduct> validCP = new List<CategoryProduct>();

            var allC = context.Categories.Select(c => c.Id).ToArray();
            var allP = context.Products.Select(c => c.Id).ToArray();


            foreach (var cp in cpDtos)
            {
                if (allC.Contains(cp.CategoryId) && allP.Contains(cp.ProductId))
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = cp.CategoryId,
                        ProductId = cp.ProductId
                    };

                    validCP.Add(categoryProduct);
                }
            }

            context.AddRange(validCP);
            context.SaveChanges();

            return $"Successfully imported {validCP.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p=>p.Price>=500 &&p.Price<=1000)
                .OrderBy(p=>p.Price)
                .Select(p=> new ProductExportDto()
                {
                    Name = p.Name ,
                    Price   =p.Price,
                    Buyer =p.Buyer.FirstName + " " + p.Buyer.LastName,
                })
                .Take(10)
                .ToList();

            return Serializer(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersSold = context
                .Users
                .Where(u=>u.ProductsSold.Count()>0)
                .OrderBy(u=>u.LastName)
                .ThenBy(u=>u.FirstName)
                .Select(u=> new UserSoldExportDto()
                {
                    FirstName = u.FirstName,
                    LasteName = u.LastName,
                    ExportSoldProductsDto = u.ProductsSold.Select(p => new ExportSoldProductsDto()
                    {
                        Name = p.Name,
                        Price=p.Price
                    })
                    //.Take(5)
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            return Serializer(usersSold, "Users");
        }
        private static string Serializer<T>(T dto, string rootName)
        {
            var sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute(rootName);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using var writer = new StringWriter(sb);
            serializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}