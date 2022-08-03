using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    [JsonObject]
    public class ExportCarsDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Make))]
        public string  Make { get; set; }

        [JsonProperty(nameof(Model))]
        public string Model { get; set; }

        [JsonProperty(nameof(TravelledDistance))]
        public long TravelledDistance { get; set; }
    }
}

//"Id": 134,
//    "Make": "Toyota",
//    "Model": "Camry Hybrid",
//    "TravelledDistance": 486872832,
