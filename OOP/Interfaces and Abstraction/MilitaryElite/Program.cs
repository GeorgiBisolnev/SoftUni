﻿using _7MilitaryElite.Implementations;
using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace _7MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ISolder> soldiers = new Dictionary<int, ISolder>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();

                string action = inputInfo[0];
                int id = int.Parse(inputInfo[1]);
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                if (action=="Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    IPrivate @private = new Private(id,firstName,lastName, salary);
                    soldiers.Add(id,@private);

                }
                else if (action== "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < inputInfo.Length; i++)
                    {
                        int inputID = int.Parse(inputInfo[i]);

                        IPrivate @private = soldiers[inputID] as IPrivate;

                        lieutenantGeneral.Privates.Add(@private);
                    }

                    soldiers.Add(id, lieutenantGeneral);

                }
                else if (action== "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    bool isValidCorp = Enum.TryParse(inputInfo[5], out Corps result);

                    if (!isValidCorp)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6  ; i < inputInfo.Length; i+=2)
                    {
                        string partName = inputInfo[i];
                        int hours = int.Parse(inputInfo[i + 1]);

                        IRepair repair = new Repair(partName, hours);
                        engineer.Repairs.Add(repair);
                    }
                    soldiers.Add(id, engineer);
                }
                else if (action== "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    bool isValidCorp = Enum.TryParse(inputInfo[5], out Corps result);

                    if (!isValidCorp)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando comando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < inputInfo.Length; i+=2)
                    {
                        string missionCode = inputInfo[i];
                        string missionStateAsString = inputInfo[i+1];

                        bool isValidMission = Enum.TryParse(missionStateAsString, out Status status);

                        if (!isValidMission)
                        {
                            continue;
                        }
                        IMission mission = new Mission(missionCode, status);

                        comando.Missions.Add(mission);
                    }

                    soldiers.Add(id, comando);

                }
                else if (action=="Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }



                input = Console.ReadLine();
            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
