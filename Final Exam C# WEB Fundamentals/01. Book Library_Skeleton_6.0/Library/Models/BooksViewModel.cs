using Microsoft.AspNetCore.Mvc;

namespace Library.Models
{
    public class BooksViewModel 
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string  Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Rating { get; set; }

        public string? Category { get; set; }
    }
}
