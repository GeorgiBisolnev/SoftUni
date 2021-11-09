using System;
using System.Collections.Generic;
using System.Linq;
namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while(heroes.Count<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch (type)
                {
                    case "Paladin":
                        heroes.Add(new Paladin(name));

                    break;
                    case "Druid":
                        heroes.Add(new Druid(name));

                        break;
                    case "Rogue":
                        heroes.Add(new Rogue(name));

                        break;
                    case "Warrior":
                        heroes.Add(new Warrior(name));

                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

            }
            foreach (var hero in heroes)
            {
                hero.CastAbility();
            }

            int BOSS = int.Parse(Console.ReadLine());
            int sumAttack = heroes.Sum(x => x.Power);
            if (BOSS<=sumAttack)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
            
        }
    }
}
