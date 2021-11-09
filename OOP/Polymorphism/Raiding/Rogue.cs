using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            Power = 80;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Rogue - {Name} hit for {Power} damage");
        }
    }
}
