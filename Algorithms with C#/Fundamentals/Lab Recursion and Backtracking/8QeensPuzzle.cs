using System;
using System.Collections.Generic;

namespace AllPaths_in_Labyrint
{
    class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCows = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            

            bool[,] arr = new bool[8, 8];

            eightQeens(arr,0);
            
        }

        private static void eightQeens(bool[,] arr, int row)
        {
            if (row==8)
            {
                printboard(arr);
                Console.WriteLine();
                return;
            }
            for (int col = 0; col < 8; col++)
            {
                 if (canPlaceQeen(row,col))
                 {
                    attackedRows.Add(row);
                    attackedCows.Add(col);
                    attackedLeftDiagonals.Add(col - row);
                    attackedRightDiagonals.Add(col + row);

                    arr[row, col] = true;
                    eightQeens(arr, row + 1);
                    arr[row, col] = false;

                    attackedRows.Remove(row);
                    attackedCows.Remove(col);
                    attackedLeftDiagonals.Remove(col - row);
                    attackedRightDiagonals.Remove(col + row);

                }
            }
        }

        private static bool canPlaceQeen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                    !attackedCows.Contains(col) &&
                    !attackedLeftDiagonals.Contains(col - row) &&
                    !attackedRightDiagonals.Contains(col + row);
        }

        private static void printboard(bool[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                    
                }
                Console.WriteLine();               
            }
        }
    }
}
