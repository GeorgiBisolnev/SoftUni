using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity) : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double FuelConsumtion => this.isEmpty ? base.FuelConsumtion : base.FuelConsumtion + 1.4;
    }
}
