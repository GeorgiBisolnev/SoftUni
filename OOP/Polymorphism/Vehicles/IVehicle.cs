using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumtion { get; set; }

        void Drive(double km);
        void Refuel(double liters);

        bool CanDrive(double km);
    }
}
