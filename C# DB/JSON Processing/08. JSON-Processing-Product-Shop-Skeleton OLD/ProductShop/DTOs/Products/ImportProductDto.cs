using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DTOs.Products
{
    [JsonObject]
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        public string Name { get; set; }


        [JsonProperty("Price")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("SellerId")]
        public int SellerId { get; set; }


        [JsonProperty("BuyerId")]
        public int? BuyerID { get; set; }

        //"Name": "Care One Hemorrhoidal",
        //"Price": 932.18,
        //"SellerId": 25,
        //"BuyerId": 24
    }
}
