using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumtion) : base(fuelQuantity, fuelConsumtion)
        {

        }

        public override double FuelConsumtion => base.FuelConsumtion + 0.9;
    }
}
