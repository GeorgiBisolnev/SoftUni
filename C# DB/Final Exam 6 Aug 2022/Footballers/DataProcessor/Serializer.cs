namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var result = context
                .Coaches
                .ToArray()
                .Where(x => x.Footballers.Count > 0)

                .Select(x => new CoachExportDto()
                {
                    FootballersCount = x.Footballers.Count,
                    CoachName = x.Name,
                    Footballers = x.Footballers.Select(x => new ExportFootballerDto()
                    {
                        Name = x.Name,
                        Position = (PositionType)x.PositionType
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();

            return MySerializer(result, "Coaches");


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

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context
                .Teams
                .ToList()
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers.Where(t=>t.Footballer.ContractStartDate>=date)
                    .OrderByDescending(f=>f.Footballer.ContractEndDate)
                    .ThenBy(f => f.Footballer.Name)
                    .Select(f => new
                    {
                        FootballerName = f.Footballer.Name,
                        ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = Enum.GetName(typeof(BestSkillType), f.Footballer.BestSkillType),
                        PositionType = Enum.GetName(typeof(PositionType), f.Footballer.PositionType),
                    })
                    //.OrderByDescending(f => f.ContractEndDate)                    
                    .ToArray()

                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams,Formatting.Indented);
        }
    }
}
