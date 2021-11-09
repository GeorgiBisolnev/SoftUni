using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumtion;

        protected Vehicle(double fuelQuantity, double fuelConsumtion, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumtion = fuelConsumtion;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity 
        { 
            get => fuelQuantity;
            set {
                if (value>TankCapacity)
                {
                    fuelQuantity = 0;
                }
                fuelQuantity = value;
            } 
        }
        public virtual double FuelConsumtion 
        { 
            get => fuelConsumtion; 
            set => fuelConsumtion = value; 
        }
        public double TankCapacity 
        { 
            get;
            set; 
        }
        public bool isEmpty { get; set; }

        public void Drive(double km)
        {
            this.FuelQuantity -= km * this.FuelConsumtion;
        }

        public virtual void Refuel(double liters)
        {
            if (liters<=0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (this.FuelQuantity+liters>this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }

        public bool CanDrive(double km)
        {
            if (this.FuelQuantity-km*this.FuelConsumtion>=0)
            {
                return true;
            }

            return false;
        }
    }
}
