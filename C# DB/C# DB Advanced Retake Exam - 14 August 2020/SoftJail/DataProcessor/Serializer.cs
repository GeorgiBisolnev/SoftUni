namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var test = context.Officers.ToArray();
            var prisonersWithCellsOfficers = context
                .Prisoners
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .ToArray()
                    .OrderBy(o => o.OfficerName),
                    TotalOfficerSalary = double.Parse($"{p.PrisonerOfficers.Sum(po => po.Officer.Salary):F2}")
                })
                .ToArray()
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id);

            return JsonConvert.SerializeObject(prisonersWithCellsOfficers,Formatting.Indented).ToString().Trim();


        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(p=>names.Contains(p.FullName))
                .Select(p=>new ExportPrisonerDto()
                {
                    Id=p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Mails = p.Mails.Select(m=> new EncryptedMessagesExportDto()
                    {
                        Description = string.Join("", m.Description.Reverse().ToArray()),
                    })
                    .ToArray(),
                })
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id)
                .ToArray();



            return MySerializer(prisoners, "Prisoners");
        }

        private static string MySerializer<T>(T dto, string rootName)
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