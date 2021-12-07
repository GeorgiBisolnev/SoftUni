using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Repositories;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astroRepo;
        private readonly IRepository<IPlanet> planetRepo;
        private readonly IMission mission;
        private int exploredPlanetsCount;
        public Controller()
        {
            astroRepo = new AstronautRepository();
            planetRepo = new PlanetRepository();
            mission = new Mission();
            exploredPlanetsCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type== "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type== "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type== "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astroRepo.Add(astronaut);
            return $"Successfully added {astronaut.GetType().Name}: {astronaut.Name}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepo.Add(planet);
            return $"Successfully added Planet: {planet.Name}!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> list = new List<IAstronaut>();

            foreach (var item in astroRepo.Models)
            {
                if (item.Oxygen>60)
                {
                    list.Add(item);
                }
            }

            if (list.Count==0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            var currPlanet = planetRepo.FindByName(planetName);
            mission.Explore(currPlanet, list);

            int deadAstronauts =0;

            foreach (var item in list)
            {
                if (item.Oxygen==0)
                {
                    deadAstronauts++;
                }
            }
            exploredPlanetsCount++;
            return $"Planet: {currPlanet.Name} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astroRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count==0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astro;

            astro = astroRepo.FindByName(astronautName);

            if (astro==null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            else
            {
                astroRepo.Remove(astro);
                return $"Astronaut {astronautName} was retired!";
            }
        }
    }
}
