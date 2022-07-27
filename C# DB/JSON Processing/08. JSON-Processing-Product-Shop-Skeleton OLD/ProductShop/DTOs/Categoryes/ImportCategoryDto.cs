using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.DTOs.Categoryes
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [Required]
        public string  Name { get; set; }
    }
}
