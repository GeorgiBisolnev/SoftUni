using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BooksController : Controller
    {

        private  LibraryDbContext context;

        public BooksController(LibraryDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Books
                .Include(b => b.Category)
                .Select(b=> new BooksViewModel()
                {
                    Id = b.Id,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title,
                    Description = b.Description,
                    Category=b.Category.Name
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var allCategories = await context.Categories.ToListAsync();

            var model = new AddNewBookViewModel()
            {
                Categories =  allCategories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Book()
            {
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title
            };

            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userBooks = await context.Users
                .Where(u => u.Id == userId)
                .Include(ub => ub.ApplicationUsersBooks)
                .ThenInclude(b => b.Book)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync();
              

            var model = userBooks.ApplicationUsersBooks
                .Select(b => new BooksViewModel()
                {
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name,
                    Id = b.BookId,
                    ImageUrl = b.Book.ImageUrl,                    
                    Rating = b.Book.Rating,
                });


            return View("Mine", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            var bookToAdd = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (!user.ApplicationUsersBooks.Any(b => b.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = bookToAdd.Id,
                    ApplicationUserId = user.Id,
                    Book = bookToAdd,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();


            var bookToRemove = user.ApplicationUsersBooks.FirstOrDefault(b => b.BookId == bookId);

            if (bookToRemove !=null)
            {
                user.ApplicationUsersBooks.Remove(bookToRemove);

                await context.SaveChangesAsync();
            }
 
            return RedirectToAction(nameof(Mine));
        }

    }
}
