using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTeamsDto
    {
        [JsonProperty("Name")]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[A-Za-z\d\s\.\-]+$")]
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
