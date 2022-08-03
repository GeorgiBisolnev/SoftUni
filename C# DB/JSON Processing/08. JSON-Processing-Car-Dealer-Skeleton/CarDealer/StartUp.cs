using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var dbcontext = new CarDealerContext();

            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));

            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();
            Console.WriteLine("OK");

            string jsonFile = File.ReadAllText("..\\..\\..\\Datasets\\suppliers.json");
            Console.WriteLine(ImportSuppliers(dbcontext, jsonFile));
            string jsonFile1 = File.ReadAllText("..\\..\\..\\Datasets\\parts.json");
            Console.WriteLine(ImportParts(dbcontext, jsonFile1));
            string jsonFile2 = File.ReadAllText("..\\..\\..\\Datasets\\cars.json");
            Console.WriteLine(ImportCars(dbcontext, jsonFile2));

            Console.WriteLine(GetSalesWithAppliedDiscount(dbcontext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] supToImport = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.AddRange(supToImport);

            context.SaveChanges();

            int count = supToImport.Count();

            return $"Successfully imported {count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var  allSupIds = context.Suppliers.Select(x=>x.Id).ToList();

            ImportPartsDto[] importPartsDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson)
                .Where(p => allSupIds.Contains(p.SupplierId))
                .ToArray(); 

            ICollection<Part> partsToAdd  = new List<Part>();

            foreach (ImportPartsDto partsDto in importPartsDtos)
            {
                if (!IsValid(partsDto))
                {
                    continue;
                }

                Part part = Mapper.Map<Part>(partsDto);

                partsToAdd.Add(part);
            }

            context.AddRange(partsToAdd);
            context.SaveChanges();

            int imported = partsToAdd.Count();

            return $"Successfully imported {imported}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson) 
        {
            List<CarDto> carDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            List<Car> cars = new List<Car>();
            List<int> existingPartsIds = context.Parts
                .Select(p => p.Id)
                .ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarDto, Car>();
            });

            var mapper = config.CreateMapper();

            foreach (var car in carDtos)
            {
                List<PartCar> partCars = new List<PartCar>();
                foreach (var id in car.PartsId.Distinct())
                {
                    if (existingPartsIds.Contains(id))
                    {
                        partCars.Add(new PartCar { CarId = car.Id, PartId = id });
                    }
                }

                Car currentCar = mapper.Map<Car>(car);
                currentCar.PartCars = partCars;
                cars.Add(currentCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customerDtos =
                JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson);

            var customers = new HashSet<Customer>();

            foreach (var dto in customerDtos)
            {
                if (!IsValid(dto))
                {
                    continue;
                }

                var customer = Mapper.Map<Customer>(dto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var saleDtos =
                 JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            var sales = Mapper.Map<HashSet<Sale>>(saleDtos);
            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new ExportOrderedCustomersDto()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(customers,Formatting.Indented);

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(m => m.Model)
                .ThenByDescending(t => t.TravelledDistance)
                .Select(c => new ExportCarsDto()
                {
                    Id=c.Id,
                    Make=c.Make,
                    Model  =    c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToArray();

            var result= JsonConvert.SerializeObject(cars,Formatting.Indented);

            return result.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Include(p => p.Parts)
                .Where(s => s.IsImporter==false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            return JsonConvert.SerializeObject(localSuppliers,Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    }).ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                    .Where(c => c.Sales.Any(s => s.Car != null))
                    .Select(c => new
                    {
                        fullName = c.Name,
                        boughtCars = c.Sales.Count(),
                        spentMoney = c.Sales
                                      .SelectMany(s => s.Car.PartCars)
                                      .Sum(pc => pc.Part.Price)
                    })
                    .OrderByDescending(c => c.spentMoney)
                    .ThenByDescending(c => c.boughtCars);

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales10 = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price)* s.Discount/100)
                            .ToString("F2")
                })
                .ToArray()
                .Take(10);

            return JsonConvert.SerializeObject(sales10, Formatting.Indented);

        }
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}