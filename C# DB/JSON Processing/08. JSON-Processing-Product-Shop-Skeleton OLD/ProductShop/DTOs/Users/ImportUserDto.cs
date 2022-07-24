using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DTOs.Users
{
    [JsonObject]
    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string  FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        [MinLength(3)]
        public string  LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
