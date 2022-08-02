using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class TicketImportDto
    {
        [JsonProperty("Price")]
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        [Required]
        [Range(typeof(sbyte),"1","10")]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
