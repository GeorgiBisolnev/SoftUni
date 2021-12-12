using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var result = recursion(n);

            Console.WriteLine(result);
        }

        private static int recursion( int n)
        {
            if (n==1)
            {
                return 1;
            }

            return n * recursion(n - 1);
        }
    }
}
