using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    internal class ImportDepWithCellDto
    {
        [Required]
        [JsonProperty(nameof(Name))]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty(nameof(Cells))]
        public ImportDepartmenCellDto[] Cells { get; set; }
    }
}
