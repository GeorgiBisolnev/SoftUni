using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumtion { get; set; }
        public double TankCapacity { get; set; }

        void Drive(double km);
        void Refuel(double liters);
        bool CanDrive(double km);

        public bool isEmpty { get; set; }
    }
}
