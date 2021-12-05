using System.Linq;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            cars.Add(car);

            return $"Successfully added car {car.Make} {car.Model} ({car.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car;
            if ((car = cars.FindBy(carVIN)) == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            Racer racer;
            if (type== "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }
            this.racers.Add(racer);
            return $"Successfully added racer {racer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerone,racertwo;

            if ((racerone= racers.FindBy(racerOneUsername))==null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }

            if ((racertwo = racers.FindBy(racerTwoUsername)) == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }            

            return map.StartRace(racerone, racertwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var orderedRacers = racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(y => y.Username).ToList();

            foreach (var item in orderedRacers)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
