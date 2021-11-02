using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            if (l>0 && w > 0 && h>0)
            {
                Box box = new Box(l, w, h);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");

            }
            else if (l<=0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
            }
            else if (w<=0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
            } else
            {
                Console.WriteLine("Height cannot be zero or negative.");
            }
            
        }
    }
}
