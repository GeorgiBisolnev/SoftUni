namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(CoachImportXml[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);

            CoachImportXml[] coachesDto = (CoachImportXml[])xmlSerializer.Deserialize(reader);

            List<Coach> validCoaches = new List<Coach>();

            foreach (var coach in coachesDto)
            {
                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (String.IsNullOrEmpty(coach.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Footballer> validFootbalers = new List<Footballer>();

                foreach (var footballer in coach.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (String.IsNullOrEmpty(footballer.ContractEndDate) || String.IsNullOrEmpty(footballer.ContractStartDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool validStartDate = DateTime.TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedStartDate);
                    bool validEndDate = DateTime.TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedEndDate);

                    if (!validStartDate || !validEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (convertedStartDate>convertedEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    

                    validFootbalers.Add(new Footballer()
                    {
                        Name = footballer.Name,
                        ContractStartDate = convertedStartDate,
                        ContractEndDate = convertedEndDate,
                        //YourEnum foo = (YourEnum)yourInt;
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        PositionType = (PositionType)footballer.PositionType

                    }); 
                }

                Coach newCoach = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality,
                    Footballers = validFootbalers
                };

                validCoaches.Add(newCoach);               
                sb.AppendLine($"Successfully imported coach - {newCoach.Name} with {newCoach.Footballers.Count} footballers.");
            }

            context.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString ().Trim();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTeamsDto[] teamDtos =
                JsonConvert.DeserializeObject<ImportTeamsDto[]>(jsonString);

            ICollection<Team> validTeams = new List<Team>();

            foreach (var team in teamDtos)
            {
                if (!IsValid(team))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validTrophies = int.TryParse(team.Trophies, out var trophiesNumber);

                if (!validTrophies || trophiesNumber<=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //List<Footballer> FootbalersToAdd = new List<Footballer>();
                var uniqueFootbalersArray = team.Footballers.Select(x => x).Distinct();

                Team newTeam = new Team()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = trophiesNumber
                };

                int importedFootbollers = 0;
                foreach (var uF in uniqueFootbalersArray)
                {
                    if (!context.Footballers.Select(id=>id.Id).Contains(uF))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer tf = new TeamFootballer()
                    {
                        Team = newTeam,
                        FootballerId = uF
                    };

                    newTeam.TeamsFootballers.Add(tf);
                    importedFootbollers++;
                }

                validTeams.Add(newTeam);
                sb.AppendLine($"Successfully imported team - {newTeam.Name} with {importedFootbollers} footballers.");
             }

            context.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
