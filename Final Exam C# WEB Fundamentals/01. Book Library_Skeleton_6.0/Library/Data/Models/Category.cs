using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.CategoryConst;

namespace Library.Data.Models
{
    public class Category
    {
        [Required]
        public int  Id   { get; set; }

        [Required, StringLength(NameMax), MinLength(NameMin)]
        public string Name { get; set; }
    }
}
