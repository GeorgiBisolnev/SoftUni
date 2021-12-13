using System;
using System.Collections.Generic;

namespace AllPaths_in_Labyrint
{
    class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());

            Console.WriteLine( Fibonachi(fib));


        }

        private static int Fibonachi(int fib)
        {
            if (fib==1 || fib == 0)
            {
                return 1;
            }

            return Fibonachi(fib - 1) + Fibonachi(fib - 2);
        }
    }
}
