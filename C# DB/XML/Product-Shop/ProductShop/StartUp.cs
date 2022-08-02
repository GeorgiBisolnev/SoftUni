using ProductShop.Data;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbcontext = new ProductShopContext();

            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();
            System.Console.WriteLine("New Database created");


        }
    }
}