using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.BookConst;

namespace Library.Models
{
    public class AddNewBookViewModel 
    {
        [Required]
        [StringLength(BookTitleMax, MinimumLength = BookTitleMin)]
        public string Title { get; set; }

        [Required]
        [StringLength(BookAuthorMax, MinimumLength = BookAuthorMin)]
        public string Author { get; set; }

        [Required]
        [StringLength(BookDescriptionMax, MinimumLength =BookDescriptionMIn)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
