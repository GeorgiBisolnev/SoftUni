using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] carinfo = Console.ReadLine().Split();
            string[] truckinfo = Console.ReadLine().Split();
            string[] businfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carinfo[1]);
            double carFuelConsumtion = double.Parse(carinfo[2]);
            double carTankC = double.Parse(carinfo[3]);

            double truckFuelQuantity = double.Parse(truckinfo[1]);
            double truckFuelConsumtion = double.Parse(truckinfo[2]);
            double truckTankC = double.Parse(truckinfo[3]);

            double busFuelQuantity = double.Parse(businfo[1]);
            double busFuelConsumtion = double.Parse(businfo[2]);
            double busTankC = double.Parse(businfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumtion,carTankC);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumtion,truckTankC);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumtion, busTankC);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string action = inputInfo[0];
                string vehicle = inputInfo[1];

                double value = double.Parse(inputInfo[2]);

                try
                {
                    if (action == "Drive")
                    {
                        if (vehicle == "Car")
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

                        }
                        else if (vehicle == "Truck")
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
                        else if (vehicle == "Bus")
                        {
                            bus.isEmpty = false;
                            if (bus.CanDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }

                    }
                    else if (action == "Refuel")
                    {
                        if (vehicle == "Truck")
                        {   
                            truck.Refuel(value);
                        }
                        else if (vehicle == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (action=="DriveEmpty")
                    {
                        bus.isEmpty = true;
                        if (bus.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                catch   (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

            
        }
    }
}
