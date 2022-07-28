using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
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

            //dbcontext.Database.EnsureDeleted();
            //dbcontext.Database.EnsureCreated();
            //Console.WriteLine("OK");

            //string jsonFile = File.ReadAllText("..\\..\\..\\Datasets\\suppliers.json");
            //Console.WriteLine(ImportSuppliers(dbcontext,jsonFile));
            //string jsonFile1 = File.ReadAllText("..\\..\\..\\Datasets\\parts.json");
            //Console.WriteLine(ImportParts(dbcontext, jsonFile1));
            string jsonFile2 = File.ReadAllText("..\\..\\..\\Datasets\\cars.json");
            Console.WriteLine(ImportCars(dbcontext, jsonFile2));
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
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}