using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Recursion(n);
        }

        private static void Recursion(int n)
        {
            if (n==0)
            {
                return;
            }
            Console.WriteLine(new string('*',n));
            Recursion(n-1);
            Console.WriteLine(new string ('#',n));
        }
    }
}
