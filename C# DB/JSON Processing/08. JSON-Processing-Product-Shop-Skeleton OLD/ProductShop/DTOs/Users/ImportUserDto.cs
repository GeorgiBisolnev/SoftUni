using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.Users
{
    [JsonObject]
    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string  FirstName { get; set; }

        [JsonProperty("lastName")]
        public string  LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
