using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumtion) : base(fuelQuantity, fuelConsumtion)
        {
        }

        public override double FuelConsumtion => base.FuelConsumtion + 1.6;

        public override void Refuel(double liters)
        {
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
