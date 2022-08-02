using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ProjectionImportDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public List<TicketImportDto> Tickets { get; set; }
    }
}

//{
//    "Name": "",
//    "NumberOfHalls": 7,
//    "Director": "Ulwin Mabosty",
//    "Tickets": [
//      {
//        "Price": 7.63,
//        "RowNumber": 5,
//        "PlayId": 4
//      },
//      {
//        "Price": 47.96,
//        "RowNumber": 9,
//        "PlayId": 3
//      }
//    ]
//  }