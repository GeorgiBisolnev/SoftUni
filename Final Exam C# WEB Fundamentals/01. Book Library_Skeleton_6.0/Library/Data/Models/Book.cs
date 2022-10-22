using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants.BookConst;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(BookTitleMax), MinLength(BookTitleMin)]
        public string Title { get; set; }

        [Required, StringLength(BookAuthorMax), MinLength(BookAuthorMin)]
        public string Author { get; set; }

        [Required, StringLength(BookDescriptionMax), MinLength(BookDescriptionMIn)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public List<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
