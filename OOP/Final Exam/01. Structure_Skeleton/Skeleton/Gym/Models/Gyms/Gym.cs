using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> allEquipment;
        private ICollection<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            athletes = new List<IAthlete>();
            allEquipment = new List<IEquipment>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight => allEquipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => allEquipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == Athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            else
            {
                athletes.Add(athlete);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            allEquipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var item in athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            var str = new StringBuilder();

            str.AppendLine($"{Name} is a {GetType().Name}:");
            if (Athletes.Count==0)
            {
                str.AppendLine("Athletes: No athletes");
            }
            else
            {
                str.AppendLine($"Athletes: {string.Join(", ", Athletes)}");
            }
            str.AppendLine($"Equipment total count: {allEquipment.Count}");
            str.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return str.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
