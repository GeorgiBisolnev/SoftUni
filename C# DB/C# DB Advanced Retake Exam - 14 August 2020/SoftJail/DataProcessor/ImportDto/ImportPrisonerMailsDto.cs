using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerMailsDto
    {
        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; }

        [Required]
        [JsonProperty("Sender")]
        public string Sender { get; set; }

        [Required]
        [JsonProperty("Address")]
        [RegularExpression(@"^([0-9a-zA-Z\s]*)( str.)$")]
        public string Address { get; set; }
    }
}


//"Description": "Invalid FullName",
//        "Sender": "Invalid Sender",
//        "Address": "No Address"
