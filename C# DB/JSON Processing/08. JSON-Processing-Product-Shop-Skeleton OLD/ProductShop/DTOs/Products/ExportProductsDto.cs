using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.Products
{
    [JsonObject]
    public class ExportProductsDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("seller")]
        public String SellerFullName { get; set; }
    }
}
