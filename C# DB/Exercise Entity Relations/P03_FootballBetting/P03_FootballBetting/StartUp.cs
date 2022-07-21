using System;
using System.Diagnostics;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Console.WriteLine("Kose Bose");

            Console.WriteLine(sw.ElapsedMilliseconds /1000.0);
        }
    }
}
