using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = Recursion(numbers, 0);

            Console.WriteLine(result);
        }

        private static int Recursion(int[] numbers, int index)
        {
            if (index==numbers.Length-1)
            {
                return numbers[index];
            }

            return numbers[index] + Recursion(numbers, index + 1);
        }
    }
}
