using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }
        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.InvalidRacerName);
                }
                else
                {
                    username = value;
                }
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.InvalidRacerBehavior);
                }
                else
                {
                    racingBehavior = value;
                }
            }
        }

        public int DrivingExperience 
        {
            get => drivingExperience;
            set
            {
                if (value<0||value>100)
                {
                    throw new Exception(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                else
                {
                    drivingExperience = value;
                }
            }
        }

        public ICar Car
        {
            get => car;
            set
            {
                if (value==(null))
                {
                    throw new Exception(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        public bool IsAvailable()
        {
            if (car.FuelAvailable>= car.FuelConsumptionPerRace)
            {
                return true;
            }

            return false;
        }

        public virtual void Race()
        {
            car.Drive();            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

                sb.AppendLine($"{GetType().Name}: {Username}");
                sb.AppendLine($"--Driving behavior: {RacingBehavior}");
                sb.AppendLine($"--Driving experience: {DrivingExperience}");
                sb.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
