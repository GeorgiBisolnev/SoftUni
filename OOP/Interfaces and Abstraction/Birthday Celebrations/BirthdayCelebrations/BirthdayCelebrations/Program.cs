using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        { 
            List<IBirth> ids = new List<IBirth>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {

                string[] info = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info[0]== "Citizen")
                {
                    ids.Add(new Citizen(info[1], int.Parse(info[2]), info[3], info[4]));
                }else if(info[0] == "Pet")
                {
                    ids.Add(new Pet(info[1], info[2]));
                }
            }

            string year = Console.ReadLine();
            foreach (var petsAndHumans in ids)
            {                
                if (year == petsAndHumans.Birthdate.Substring(petsAndHumans.Birthdate.Length-4))
                {
                    Console.WriteLine(petsAndHumans.Birthdate);
                }
            }
            Console.WriteLine();
        }
    }
}
