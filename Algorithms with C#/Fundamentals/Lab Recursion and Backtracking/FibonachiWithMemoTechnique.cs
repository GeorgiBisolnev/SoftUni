using System;
using System.Collections.Generic;

namespace AllPaths_in_Labyrint
{
    class Program
    {
        private static Dictionary<long, long> memoResults = new Dictionary<long, long>();
        static void Main(string[] args)
        {
            long fib = long.Parse(Console.ReadLine());

            Console.WriteLine( Fibonachi(fib));


        }

        private static long Fibonachi(long fib)
        {
            if (fib==1 || fib == 0)
            {
                return 1;
            }

            if (memoResults.ContainsKey(fib))
            {
                return memoResults[fib];
            }

            long result =  Fibonachi(fib - 1) + Fibonachi(fib - 2);

            memoResults.Add(fib, result);

            return result;
        }
    }
}
