using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumtion;

        protected Vehicle(double fuelQuantity, double fuelConsumtion)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumtion = fuelConsumtion;
        }

        public double FuelQuantity 
        { 
            get => fuelQuantity; 
            set => fuelQuantity = value; 
        }
        public virtual double FuelConsumtion 
        { 
            get => fuelConsumtion; 
            set => fuelConsumtion = value; 
        }

        public void Drive(double km)
        {
            FuelQuantity -= km * FuelConsumtion;
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
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
