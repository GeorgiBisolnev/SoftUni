namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
           // DbInitializer.ResetDatabase(db);

            BookShopContext context = new BookShopContext();

            //string str= Console.ReadLine();
            //int str= int.Parse( Console.ReadLine());
            //System.Console.WriteLine(IncreasePrices(context));
            IncreasePrices(context);

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder str = new StringBuilder();

            AgeRestriction ageRestriction;

            bool isParsed = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (!isParsed)
            {
                return str.ToString();
            } 

            var books = context
                .Books
                .Where(b=>b.AgeRestriction== ageRestriction)
                .Select(t=>t.Title)
                .ToArray()
                .OrderBy(b=>b);

            foreach (var book in books)
            {
                str.AppendLine(book);
            }

            return str.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder str = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Copies < 5000 && b.EditionType==EditionType.Gold)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var book in books)
            {
                str.AppendLine(book.Title);
            }

            return str.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder str = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price>40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b=>b.Price)
                .ToArray();

            foreach (var book in books)
            {
                str.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return str.ToString().TrimEnd();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder str = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var book in books)
            {
                str.AppendLine($"{book.Title}");
            }

            return str.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var str = new StringBuilder();

            var para = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(s => s.ToLower()).ToArray();

            var books = context.Books
                    .Where(b => b.BookCategories
                                            .Any(bc => para.Contains(bc.Category.Name.ToLower())))
                    .Select(b => b.Title)
                    .OrderBy(t => t)
                    .ToList();

            foreach (var book in books)
            {
                str.AppendLine($"{book}");
            }

            return str.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var str = new StringBuilder();
            DateTime dateTime;
            try
            {
                dateTime= DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture); 
            }
            catch
            {
                return String.Empty;
            }
            var books = context.Books
                    .Where(b=>b.ReleaseDate<dateTime)
                    .OrderByDescending(t => t.ReleaseDate)
                    .Select(b => new
                    {
                        b.Title,
                        b.EditionType,
                        b.Price
                    })                    
                    .ToList();

            foreach (var book in books)
            {
                str.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return str.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var str = new StringBuilder();

            var autors = context
                    .Authors
                    .Where(a=>a.FirstName.EndsWith(input))
                    .Select(a => new
                    {
                        fullName = a.FirstName + " " + a.LastName
                    })
                    .ToArray()
                    .OrderBy(a=>a.fullName);

            foreach (var a in autors)
            {
                str.AppendLine(a.fullName);
            }

            return str.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var str = new StringBuilder();

            var titles = context
                    .Books
                    .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                    .Select(a => new
                    {
                        a.Title
                    })
                    .ToArray()
                    .OrderBy(a => a.Title);

            foreach (var a in titles)
            {
                str.AppendLine(a.Title);
            }

            return str.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var str = new StringBuilder();

            var arr = context
                    .Books
                    .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                    .OrderBy(b => b.BookId)
                    .Select(b => new
                    {
                        b.Title,
                        AuthorsName = b.Author.FirstName + " " + b.Author.LastName
                    })                    
                    .ToArray();


            foreach (var book in arr)
            {
                str.AppendLine($"{book.Title} ({book.AuthorsName})");
            }

            return str.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                    .Books
                    .Count(b => b.Title.Length > lengthCheck);


        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var arr = context
                .Authors
                .Select(a => new
                {
                    AuthorsFullName = $"{a.FirstName} {a.LastName}",
                    TotalBookCopies = a.Books.Sum(b=>b.Copies)
                })
                .ToArray()
                .OrderByDescending(a=>a.TotalBookCopies);
            var str = new StringBuilder();
            foreach (var i in arr)
            {
                str.AppendLine($"{i.AuthorsFullName} - {i.TotalBookCopies}");
            }

            return str.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var arr = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(a => a.profit)
                .ThenBy(c => c.Name)
                .ToArray();
                
            var str = new StringBuilder();
            foreach (var i in arr)
            {
                str.AppendLine($"{i.Name} ${i.profit:F2}");
            }

            return str.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Top3Books = c.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate,
                        Year = b.Book.ReleaseDate.Value.Year
                    })
                    .OrderByDescending(y => y.ReleaseDate.Value)
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(c=>c.CategoryName)
                .ToArray();

            var str= new StringBuilder();
            foreach (var c in categories)
            {
                str.AppendLine($"--{c.CategoryName}");
                foreach (var book in c.Top3Books)
                {
                    str.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return str.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncreacePriceBy5 = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToIncreacePriceBy5)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200);

            context.Books.RemoveRange   (booksToRemove);

            int removedBooks = booksToRemove.Count();

            context.SaveChanges();

            return removedBooks;
        }

    }
}
