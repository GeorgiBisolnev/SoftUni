using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                var anyItems = planet.Items.Any();

                if (!anyItems)
                {
                    break;
                }

                while (astronaut.CanBreath )
                {
                    var item = planet.Items.FirstOrDefault();
                    if (string.IsNullOrEmpty(item))
                    {
                        break;
                    }
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                }
                
            }
        }
    }
}
