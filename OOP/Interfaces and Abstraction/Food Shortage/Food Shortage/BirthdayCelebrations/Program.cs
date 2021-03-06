using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> allFood = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);                
                if (info.Length==4)
                {
                    allFood.Add(info[0], new Citizen(info[0], int.Parse(info[1]), info[2], info[3]));
                }
                else if (info.Length==3)
                {                    
                    allFood.Add(info[0], new Rebel(info[0], int.Parse(info[1]), info[2]));
                }
            }

            string command;
            int totalFood = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                if (allFood.ContainsKey(command))
                {
                    allFood[command].BuyFood();
                    totalFood += allFood[command].Food;
                }
            }
            Console.WriteLine(totalFood);
        }
    }
}
