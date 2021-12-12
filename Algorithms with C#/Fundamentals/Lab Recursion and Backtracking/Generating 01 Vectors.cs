using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            recursion(arr,0);
        }

        private static void recursion(int[] arr, int index)
        {
            if (index==arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty,arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                recursion(arr, index + 1);
            }
        }
    }
}
