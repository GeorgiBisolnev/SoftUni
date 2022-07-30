using CarDealer.Data;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var context = new CarDealerContext();

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

            string xmlFile5 = File.ReadAllText("../../../Datasets/sales.xml");
            System.Console.WriteLine(ImportSales(context, xmlFile5));




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
    }
}