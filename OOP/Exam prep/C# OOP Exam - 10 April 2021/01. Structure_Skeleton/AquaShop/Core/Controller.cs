using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium newAquarium;
            if (aquariumType== "FreshwaterAquarium")
            {
                newAquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                newAquarium = new SaltwaterAquarium(aquariumName);
            } else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            aquariums.Add(newAquarium);
            return $"Successfully added {newAquarium.GetType().Name}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration newDecoration;
            if (decorationType== "Ornament")
            {
                newDecoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                newDecoration = new Plant();
            }
            else 
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            decorations.Add(newDecoration);
            return $"Successfully added {newDecoration.GetType().Name}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish newFish;
            if (fishType== "FreshwaterFish")
            {
                newFish = new FreshwaterFish(fishName,fishSpecies,price);
            }
            else if (fishType == "SaltwaterFish")
            {
                newFish = new SaltwaterFish(fishName, fishSpecies, price);
            } else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var aquariumToInputFish = aquariums.First(x => x.Name == aquariumName);

            if (newFish.GetType().Name == "SaltwaterFish" && aquariumToInputFish.GetType().Name== "SaltwaterAquarium")
            {
                foreach (var aquarium in aquariums)
                {
                    if (aquarium.Name== aquariumName)
                    {
                        aquarium.AddFish(newFish);
                    }
                }
            }
            else if (newFish.GetType().Name == "FreshwaterFish" && aquariumToInputFish.GetType().Name == "FreshwaterAquarium")
            {
                foreach (var aquarium in aquariums)
                {
                    if (aquarium.Name == aquariumName)
                    {
                        aquarium.AddFish(newFish);
                    }
                }
            } else
            {
                return "Water not suitable.";
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal valueOfAquarium = 0;

            valueOfAquarium += aquariums.First(x => x.Name == aquariumName).Fish.Sum(c => c.Price);
            valueOfAquarium += aquariums.First(x => x.Name == aquariumName).Decorations.Sum(c => c.Price);

            return $"The value of Aquarium {aquariumName} is {valueOfAquarium:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            aquariums.First(x => x.Name == aquariumName).Feed();

            return $"Fish fed: {aquariums.First(x => x.Name == aquariumName).Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var findDecoration = decorations.Models.FirstOrDefault(c => c.GetType().Name == decorationType);

            if (findDecoration==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            foreach (var aquarium in aquariums)
            {
                if (aquarium.Name==aquariumName)
                {
                    aquarium.AddDecoration(findDecoration);
                    decorations.Remove(findDecoration);
                    break;
                }
            }

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var str = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                str.AppendLine(aquarium.GetInfo());
            }

            return str.ToString().TrimEnd();
        }
    }
}
