using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsepower;
        private double fuelavailable;
        private double fuelconsumptionperrace;
        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;

        }
        public string Make
        {
            get => make;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }

                    make = value;

            }

        }

        public string Model {
            get => model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.InvalidCarModel);
                }
                else
                {
                    model = value;
                }
            }
        }

        public string VIN {
            get => vin;
            set
            {
                if (value.Length!=17)
                {
                    throw new Exception(ExceptionMessages.InvalidCarVIN);
                }
                else
                {
                    vin = value;
                }
            }
        }

        public int HorsePower {
            get => horsepower;
            set
            {
                if (value<0)
                {
                    throw new Exception(ExceptionMessages.InvalidCarHorsePower);
                }

                    horsepower = value;

            }
        }

        public double FuelAvailable 
        {
            get => fuelavailable;
            set
            {
                if (value<0)
                {
                    fuelavailable = 0;
                }
                 fuelavailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => fuelconsumptionperrace;
            set
            {
                if (value<0)
                {
                    throw new Exception(ExceptionMessages.InvalidCarFuelConsumption);
                }

                    fuelconsumptionperrace = value;

            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= fuelconsumptionperrace;
        }
    }
}
