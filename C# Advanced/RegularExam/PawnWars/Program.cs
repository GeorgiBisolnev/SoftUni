using System;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int xb = 0, yb = 0, xw = 0, yw = 0;
            for (int i = 0; i < 8; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = row[j];
                    if (row[j]=='b')
                    {
                        xb = i;yb = j;
                    }
                    else if (row[j] == 'w')
                    {
                        xw = i; yw = j;
                    }
                }
            }
            bool turn = true;
            bool foundWinner = false;
            while ((xw>0) && (xb<7))
            {
                if (turn)
                {
                    turn = false;
                    board[xw, yw] = '-';                    
                    if (inside(board,xw-1,yw-1)=='b' || inside(board, xw - 1, yw + 1) == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {cor(xb, yb)}.");                        
                        foundWinner = true;
                        break;
                    }
                    else
                    {
                        board[xw - 1, yw] = 'w';
                        xw--;
                    }
                }else
                {
                    turn = true;
                    board[xb, yb] = '-';                    
                    if (inside(board,xb + 1, yb - 1) == 'w' || inside(board, xb + 1, yb + 1) == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {cor(xw, yw)}.");
                        foundWinner = true;
                        break;
                    }
                    else
                    {
                        board[xb +1, yb] = 'b';
                        xb++;
                    }
                }
                //Console.WriteLine("****");
                //for (int i = 0; i < 8; i++)
                //{
                //    for (int j = 0; j < 8; j++)
                //    {
                //        Console.Write(board[i,j]);
                //    }
                //    Console.WriteLine();
                //}

            }

            if (foundWinner==false)
            {
                if (xw==0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {cor(xw,yw)}.");
                }
                else
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {cor(xb, yb)}.");
                }
            }

            
        }
        public static string cor(int x, int y)
        {
            int row = 8-x;
            string col="";
            if (y == 0)
            {
                col = "a";
            }
            else if (y == 1)
            {
                col = "b";
            }
            else if (y == 2)
            {
                col = "c";
            }
            else if (y == 3)
            {
                col = "d";
            }
            else if (y == 4)
            {
                col = "e";
            }
            else if (y == 5)
            {
                col = "f";
            }
            else if (y == 6)
            {
                col = "g";
            }
            else if (y == 7)
            {
                col = "h";
            }
            return col+row;
        }

        public static char inside(char[,] board, int x, int y)
        {
            if (x >= 0 && y <= 7 && x<=7 && y>=0)
            {
                return board[x, y];
            }
            else 
                return '-';
        }
    }
}
