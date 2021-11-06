using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IId> ids = new List<IId>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {

                string[] info = command.Split();
                if (info.Length>2)
                {
                    ids.Add(new Citizen(info[0], int.Parse(info[1]), info[2]));
                }else
                {
                    ids.Add(new Robot(info[0], info[1]));
                }
            }

            string delete = (Console.ReadLine());

            foreach (var humanOrRobot in ids)
            {
                if (humanOrRobot.id.Length> delete.Length && humanOrRobot.id.Substring(humanOrRobot.id.Length- delete.Length, delete.Length) == delete && delete!="")
                {
                    Console.WriteLine(humanOrRobot.id);
                }
            }
        }
    }
}
