using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.CategoriesProducts
{
    [JsonObject]
    public  class ImportCategoryProductDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
