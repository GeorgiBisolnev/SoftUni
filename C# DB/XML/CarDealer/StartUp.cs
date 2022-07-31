using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var context = new CarDealerContext();
            //Imports
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //System.Console.WriteLine("Done!");

                //string xmlFile = File.ReadAllText("../../../Datasets/suppliers.xml");

                //System.Console.WriteLine(ImportSuppliers(context, xmlFile));

                //string xmlFile2 = File.ReadAllText("../../../Datasets/parts.xml");
                //System.Console.WriteLine(ImportParts(context, xmlFile2));

                //string xmlFile3 = File.ReadAllText("../../../Datasets/cars.xml");
                //System.Console.WriteLine(ImportCars(context, xmlFile3));

                //string xmlFile4 = File.ReadAllText("../../../Datasets/customers.xml");
                //System.Console.WriteLine(ImportCustomers(context, xmlFile4));

                //string xmlFile5 = File.ReadAllText("../../../Datasets/sales.xml");
                //System.Console.WriteLine(ImportSales(context, xmlFile5));
            }

            //Exports
            {
                //System.Console.WriteLine(GetCarsWithDistance(context));
                //System.Console.WriteLine(GetCarsFromMakeBmw(context));
                //Console.WriteLine(GetLocalSuppliers(context));
                Console.WriteLine(GetCarsWithTheirListOfParts(context));
            }

        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportSupplierDto[] supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            Supplier[] suppliers = supplierDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToArray();

            context.AddRange(suppliers);
            context.SaveChanges();


            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ImportPartDto[] partDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);

            int[] idArray = context
                .Suppliers
                .Select(id => id.Id)
                .ToArray();

            Part[] parts = partDtos
                .Where(partId=> idArray.Contains(partId.SupplierId))
                .Select(part => new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId
                })
                .ToArray();


            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]),xmlRoot);

            StringReader reader = new StringReader(inputXml);
            ImportCarDto[] carsDto = (ImportCarDto[])xmlSerializer.Deserialize(reader);

            ICollection<Car> cars = new List<Car>();

            foreach (var cDto in carsDto)
            {
                Car car = new Car()
                {
                    Make = cDto.Make,
                    Model = cDto.Model, 
                    TravelledDistance = cDto.TravelledDistance
                };

                ICollection<PartCar> partsCarToImport = new List<PartCar>();

                foreach (int part in cDto.Parts.Select(p=>p.Id).Distinct())
                {
                    if (context.Parts.Any(id=>id.Id == part))
                    {
                        PartCar newPartCar = new PartCar()
                        {
                            Car = car,
                            PartId = part
                        };
                        partsCarToImport.Add(newPartCar);
                    }
                }

                car.PartCars = partsCarToImport;

                cars.Add(car);

            }

            context.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]),xmlRootAttribute);

            StringReader reader = new StringReader(inputXml);
            ImportCustomersDto[] customersDto = (ImportCustomersDto[])xmlSerializer.Deserialize(reader);

            Customer[] customersToAdd = customersDto
                .Select(customer=>new Customer()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                })
                .ToArray();

            context.Customers.AddRange(customersToAdd);
            context.SaveChanges();


            return $"Successfully imported {customersToAdd.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute Root = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]), Root);

            StringReader reader = new StringReader(inputXml);
            ImportSalesDto[] importSalesDtos = (ImportSalesDto[])xmlSerializer.Deserialize(reader);

            ICollection<Sale> salesToAdd = new List<Sale>();

            foreach (var sDto in importSalesDtos)
            {
                if (context.Cars.Any(id=>id.Id == sDto.CarId))
                {
                    Sale s = new Sale()
                    {
                        CarId=sDto.CarId,
                        CustomerId = sDto.CustomerId,
                        Discount = sDto.Discount
                    };

                    salesToAdd.Add(s);

                }
            }

            context.AddRange(salesToAdd);
            context.SaveChanges();

            return $"Successfully imported {salesToAdd.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsWithDistanceDto[] carDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("cars");
            XmlSerializerNamespaces namespacexml = new XmlSerializerNamespaces();
            namespacexml.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]),rootAttribute);

            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            xmlSerializer.Serialize(sw, carDtos,namespacexml);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarsFromMakeBmwDto[] exportBMW = context
                .Cars
                .Where(c=>c.Make=="BMW")
                .OrderBy(m=>m.Model)
                .ThenByDescending(c=>c.TravelledDistance)
                .Select(c => new ExportCarsFromMakeBmwDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance= c.TravelledDistance
                })
                .ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromMakeBmwDto[]),xmlRootAttribute);

            StringBuilder stringBuilder = new StringBuilder();
            using StringWriter sw = new StringWriter(stringBuilder);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(sw, exportBMW, namespaces);

            return sw.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSuppliersDto[] suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto()
                {
                    Name = s.Name,
                    Id = s.Id,
                    PartsCount = (string)s.Parts.Count().ToString()
                })
                .ToArray();


            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("suppliers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), xmlRootAttribute);

            StringBuilder stringBuilder = new StringBuilder();
            using StringWriter sw = new StringWriter(stringBuilder);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(sw, suppliers, namespaces);

            return sw.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarsWithTheirPartsDto[] cParts = context
                .Cars
                .Select(c=> new ExportCarsWithTheirPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(cp=> new ExportCarPartsDto()
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price
                    })
                    .OrderByDescending(cp=>cp.Price)
                    .ToArray(),
                })
                .OrderByDescending(c=>c.TravelledDistance)
                .ThenBy(c=>c.Model)
                .Take(5)
                .ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithTheirPartsDto[]), xmlRootAttribute);

            StringBuilder stringBuilder = new StringBuilder();
            using StringWriter sw = new StringWriter(stringBuilder);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(sw, cParts, namespaces);

            return sw.ToString().TrimEnd();
        }
    }
}