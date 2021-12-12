using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            var arr = new char[row,col];
            for (int i = 0; i < row; i++)
            {
                var symbols = Console.ReadLine().ToCharArray();
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = symbols[j];
                }
            }

            Recursion(arr,0,0, new List<string>(),"");

        }

        private static void Recursion(char[,] arr, int row, int col, List<string> directions,string direction)
        {
            if (row<0 || row>arr.GetLength(0)-1 || col<0 || col>arr.GetLength(1)-1)
            {
                return;
            }

            if (arr[row,col]=='*' || arr[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (arr[row, col]=='e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            
            arr[row, col] = 'v';
            Recursion(arr, row, col + 1, directions, "R");
            Recursion(arr, row, col - 1, directions, "L");
            Recursion(arr, row-1, col, directions, "U");
            Recursion(arr, row+1, col, directions, "D");
            arr[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);



        }
    }
}
