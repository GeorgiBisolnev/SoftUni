using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Core.Contracts
{
    public interface IController
    {
        
        string AddAstronaut(string type, string astronautName);

        string AddPlanet(string planetName, params string[] items);

        string RetireAstronaut(string astronautName);

        string ExplorePlanet(string planetName);

        string Report();
    }
}
