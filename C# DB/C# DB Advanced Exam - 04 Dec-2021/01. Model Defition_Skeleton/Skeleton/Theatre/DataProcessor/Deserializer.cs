namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(reader);

            ICollection<Play> validPlays = new List<Play>();

            foreach (var play in playDtos)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration =  TimeSpan.ParseExact(play.Duration,"c", CultureInfo.InvariantCulture);

                if (duration.Hours <1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }



                if (!Enum.TryParse(typeof(Genre), play.Genre, out var genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validPlays.Add(new Play()
                {
                    Description = play.Description,
                    Duration = duration,
                    Genre = (Genre)genre,
                    Rating = play.Rating,
                    Screenwriter = play.Screenwriter,
                    Title = play.Title,

                });

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating)); 
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(reader);

            ICollection<Cast> validCasts = new List<Cast>();


            foreach (var cast in castDtos)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validCasts.Add(new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId,

                });

                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter? "main" : "lesser"));
            }
            context.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<Theatre> validTheatres = new List<Theatre>();

            var theatres = JsonConvert.DeserializeObject<ProjectionImportDto[]>(jsonString);

            foreach (var t in theatres)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre validTheratre = new Theatre()
                {
                    Director = t.Director,
                    Name = t.Name,
                    NumberOfHalls = t.NumberOfHalls,

                };

                foreach (var tiket in t.Tickets)
                {

                    if (!IsValid(tiket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTheratre.Tickets.Add(new Ticket()
                    {
                        PlayId = tiket.PlayId,
                        Price = tiket.Price,
                        RowNumber = tiket.RowNumber
                    });
                }

                validTheatres.Add(validTheratre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre,t.Name, validTheratre.Tickets.Count()));

            }

            context.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
