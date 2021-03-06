using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planets;

        public void Add(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            foreach (var planet in planets)
            {
                if (planet.Name==name)
                {
                    return planet;
                }
            }

            return null;
        }

        public bool Remove(IPlanet model) => planets.Remove(model);
    }
}
