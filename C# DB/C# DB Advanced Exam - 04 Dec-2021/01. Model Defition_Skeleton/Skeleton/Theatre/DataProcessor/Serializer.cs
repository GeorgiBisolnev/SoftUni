namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .Include(t => t.Tickets)
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() > 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = decimal.Parse(t.Tickets.Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Sum(tc => tc.Price).ToString("F2")),
                    Tickets = t.Tickets.Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Select(tc => new
                        {
                            Price = decimal.Parse(tc.Price.ToString("F2")),
                            RowNumber = tc.RowNumber
                        })
                        .OrderByDescending(tc => tc.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();


            return JsonConvert.SerializeObject(theatres,Formatting.Indented);


        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new PlayExportDto()
                {
                    Title = p.Title,
                    Rating = p.Rating==0f? "Premier" : p.Rating.ToString(),
                    Duration = p.Duration.ToString("c"),
                    //Genre = Enum.GetName(typeof(Genre),p.Genre),
                    Genre =  p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c=>c.IsMainCharacter)
                    .Select(c => new ActiorExportDto()
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(a=>a.FullName)
                    .ToArray()

                })
                .OrderBy(p => p.Title)
                .ThenByDescending(g=>g.Genre)
                .ToList();

            string result = SerializerP(plays, "Plays");

            return result.ToString().TrimEnd();

        }

        private static string SerializerP<T>(T dto, string rootName)
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
