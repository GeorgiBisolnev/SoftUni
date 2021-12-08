using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Workshops;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private int coloredEggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            coloredEggs = 0;
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny currBunny;
            if (bunnyType== "HappyBunny")
            {
                currBunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType== "SleepyBunny")
            {
                currBunny = new SleepyBunny(bunnyName);
            } else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            bunnies.Add(currBunny);

            return $"Successfully added {currBunny.GetType().Name} named {currBunny.Name}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            bool foundBunny = bunnies.Models.Any(x => x.Name == bunnyName);

            if (!foundBunny)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            var curDye = new Dye(power);

            foreach (var bunny in bunnies.Models)
            {
                if (bunny.Name==bunnyName)
                {
                    bunny.AddDye(curDye);
                    break;
                }
            }

            return $"Successfully added dye with power {curDye.Power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var curEgg = new Egg(eggName,energyRequired);

            eggs.Add(curEgg);

            return $"Successfully added egg: {curEgg.Name}!";
        }

        public string ColorEgg(string eggName)
        {
            var workshop = new Workshop();
            var sortedBunnyes = bunnies.Models.Where(y=>y.Energy>=50).ToList();
            var anyBunnyReady = sortedBunnyes.Count > 0;

            if (!anyBunnyReady)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            var egg = eggs.Models.First(x => x.Name == eggName);

            foreach (var bunny in bunnies.Models.Where(y => y.Energy >= 50).OrderByDescending(x => x.Energy).ToList())
            {
                workshop.Color(egg, bunny);

                if (egg.IsDone())
                {
                    break;
                }
                    
                
                if (bunny.Energy==0)
                {
                    bunnies.Remove(bunny);
                }

            }
            if (egg.IsDone())
            {
                coloredEggs++;
                return $"Egg {egg.Name} is done.";
            }
            else
            {
                return $"Egg {egg.Name} is not done.";
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                int numOfDyes = 0;
                foreach (var dye in bunny.Dyes)
                {
                    if (!dye.IsFinished())
                    {
                        numOfDyes++;
                    }
                }

                sb.AppendLine($"Dyes: {numOfDyes} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
