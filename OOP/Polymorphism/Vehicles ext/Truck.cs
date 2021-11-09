using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumtion, double tankCapacity) : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double FuelConsumtion => base.FuelConsumtion + 1.6;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
