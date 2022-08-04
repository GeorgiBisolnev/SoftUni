namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

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
                    DateTime.TryParse(prisoner.IncarcerationDate, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime incarcerationDate);

                if (!incarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (prisoner.ReleaseDate!=null)
                {                
                    bool ReleaseDateValid =
                        DateTime.TryParse(prisoner.ReleaseDate, CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime relDate);
                    if (!ReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                }
                DateTime? releaseDate;
                if (prisoner.ReleaseDate == null)
                {
                    releaseDate = null;
                }
                else 
                    releaseDate = DateTime.Parse(prisoner.ReleaseDate, CultureInfo.InvariantCulture);

                Prisoner newPrisoner = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname=prisoner.NickName,
                    Age=prisoner.Age,
                    IncarcerationDate = 
                        DateTime.Parse(prisoner.IncarcerationDate, CultureInfo.InvariantCulture),
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
            throw new NotImplementedException();
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