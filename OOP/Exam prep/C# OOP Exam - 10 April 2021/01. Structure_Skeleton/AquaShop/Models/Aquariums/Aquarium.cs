using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get;
        }
        public int Comfort
        {
            get => Decorations.Sum(x => x.Comfort);
        }

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Capacity==Fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var str = new StringBuilder();

            str.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (Fish.Count==0)
            {
                str.AppendLine("none");
            }
            else
            {
                str.AppendLine("Fish: " + string.Join(", ", this.Fish));
                str.AppendLine($"Decorations: {Decorations.Count}");
                str.AppendLine($"Comfort: {this.Comfort}");
            }

            return str.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
    }
}
