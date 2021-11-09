using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] carinfo = Console.ReadLine().Split();
            string[] truckinfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carinfo[1]);
            double carFuelConsumtion = double.Parse(carinfo[2]);

            double truckFuelQuantity = double.Parse(truckinfo[1]);
            double truckFuelConsumtion = double.Parse(truckinfo[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumtion);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumtion);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string action = inputInfo[0];
                string vehicle = inputInfo[1];

                double value = double.Parse(inputInfo[2]);

                if (action=="Drive")
                {
                    if (vehicle=="Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }

                    } else if (vehicle == "Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }

                    }

                }
                else if (action == "Refuel")
                {
                    if (vehicle == "Truck")
                    {
                        truck.Refuel(value);
                    }
                    else
                    {
                        car.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");

            
        }
    }
}
