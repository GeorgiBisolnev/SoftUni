namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepWithCellDto[] depDtos =
                JsonConvert.DeserializeObject<ImportDepWithCellDto[]>(jsonString);

            ICollection<Department> validDep = new List<Department>();

            foreach (var depDto in depDtos)
            {
                if (!IsValid(depDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!depDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (depDto.Cells.Any(c=>!IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = depDto.Name,
                };

                foreach (var item in depDto.Cells)
                {
                    Cell cell = new Cell()
                    {
                        CellNumber = item.CellNumber,
                        HasWindow = item.HasWindow,
                    };

                    department.Cells.Add(cell);
                }
                
                validDep.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.AddRange(validDep);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerWithMailsDto[] dtoPrisoners= 
                    JsonConvert.DeserializeObject<ImportPrisonerWithMailsDto[]>(jsonString);

            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisoner in dtoPrisoners)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (prisoner.Mails.Any(p=>!IsValid(p)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool incarcerationDateValid = 
                    DateTime.TryParseExact(prisoner.IncarcerationDate,"dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime incarcerationDate);

                if (!incarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                DateTime relDate=DateTime.Now;
                if (prisoner.ReleaseDate!=null)
                {                
                    bool ReleaseDateValid =
                        DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out  relDate);
                    if (!ReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                }
                DateTime? releaseDate;
                if (String.IsNullOrEmpty(prisoner.ReleaseDate))
                {
                    releaseDate = null;
                }
                else 
                    releaseDate = relDate;

                Prisoner newPrisoner = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname=prisoner.NickName,
                    Age=prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate= releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,               
                };

                foreach (var mail in prisoner.Mails)
                {
                    Mail newMail = new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address,
                    };

                    newPrisoner.Mails.Add(newMail);
                }
                
                validPrisoners.Add(newPrisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(ImportOficersWithPrisonersDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);

            ImportOficersWithPrisonersDto[] OfficersDto = 
                    (ImportOficersWithPrisonersDto[])xmlSerializer.Deserialize(reader);

            foreach (var ofDto in OfficersDto)
            {
                if (!IsValid(ofDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool validEnumPosition =
                Enum.TryParse(typeof(Position), ofDto.Position, out object posObj);
                bool validEnumWeapon =
                Enum.TryParse(typeof(Position), ofDto.Weapon, out object weapObj);

                if (!validEnumPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!validEnumWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!context.Departments.Any(id=>id.Id == ofDto.DepartmentId))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
            }

            
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