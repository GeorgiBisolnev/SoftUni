using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository repoEquipment;
        private List<IGym> gyms;
        public Controller()
        {
            repoEquipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete newAthlete;
            if (athleteType== "Boxer")
            {
                newAthlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType== "Weightlifter")
            {
                newAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            if (gyms.First(x => x.Name == gymName).GetType().Name[0] == athleteType[0])
            {
                gyms.First(x => x.Name == gymName).AddAthlete(newAthlete);
                return $"Successfully added {athleteType} to {gymName}.";
            } 
            else
            {
                return "The gym is not appropriate.";
            }            
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment newEquipment;
            if (equipmentType== "BoxingGloves")
            {
                newEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                newEquipment = new Kettlebell();
            } else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            repoEquipment.Add(newEquipment);

            return $"Successfully added {newEquipment.GetType().Name}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym newGym;
            if (gymType== "BoxingGym")
            {
                newGym = new BoxingGym(gymName);
            }
            else if (gymType== "WeightliftingGym")
            {
                newGym = new WeightliftingGym(gymName);
            } else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            gyms.Add(newGym);
            return $"Successfully added {newGym.GetType().Name}.";
        }

        public string EquipmentWeight(string gymName)
        {
            double eqWeight = gyms.First(x => x.Name == gymName).EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {eqWeight:f2} grams.";

        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentToBeAdd = repoEquipment.FindByType(equipmentType);

            if (equipmentToBeAdd==null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            else
            {
                gyms.First(x => x.Name == gymName).AddEquipment(equipmentToBeAdd);
                repoEquipment.Remove(equipmentToBeAdd);
                return $"Successfully added {equipmentType} to {gymName}.";
            }
        }

        public string Report()
        {
            var str = new StringBuilder();
            foreach (var itme in gyms)
            {
                str.AppendLine(itme.GymInfo());
            }

            return str.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            gyms.First(x => x.Name == gymName).Exercise();
            return $"Exercise athletes: {gyms.First(x => x.Name == gymName).Athletes.Count}.";
        }
    }
}
