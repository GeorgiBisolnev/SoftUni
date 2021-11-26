using NUnit.Framework;
using System;

namespace CarManager.Tests
{
    public class CarTests
    {
        private string imake="Pegeout";
        private string imodel="206";
        private double ifuelConsum=5.5;
        private double ifuelCapacity=50.5;
        private double ifuelAmount = 0;
        private Car icar;
        [SetUp]
        public void Setup()
        {
            icar = new Car(imake, imodel, ifuelConsum, ifuelCapacity);
        }

        [TestCase("BMW","3",9.5,50.5)]
        [TestCase("Pegeout","206",0.1,100)]
        public void CreatingCarMustDoPerfectlyFine(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car( make,  model,  fuelConsumption,  fuelCapacity);

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);

        }

        [TestCase("", "3", 9.5, 50.5)]
        [TestCase(null, "206", 0.1, 100)]
        public void CreatingCarMustretunErrorinvalidMake(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(()=>new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [TestCase("Kia", "", 9.5, 50.5)]
        [TestCase("Lada", null, 0.1, 100)]
        public void CreatingCarMustretunErrorinvalidModel(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [TestCase("Kia", "A", 0, 50.5)]
        [TestCase("Lada", "B", -1, 100)]
        [TestCase("Lada", "B", -100, 100)]
        public void CreatingCarMustretunErrorinvalidFuelConsumation(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [TestCase("Kia", "A", 1, 0)]
        [TestCase("Lada", "B", 2, -100)]
        [TestCase("Lada", "B", 5, -0.5)]
        public void CreatingCarMustretunErrorinvalidFuelCapacity(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(50.5)]
        [TestCase(50)]
        public void RefuelMustWorkFine(double re)
        {
            icar.Refuel(re);
            Assert.AreEqual(icar.FuelAmount, re);
        }
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-50.5)]
        [TestCase(0)]
        public void RefuelMustReturnError(double re)
        {            
            Assert.Throws<ArgumentException>(()=> icar.Refuel(re));
        }
        [TestCase(100)]
        [TestCase(50.6)]
        [TestCase(60)]
        public void RefuelOverCapacityMustWorkFine(double re)
        {
            icar.Refuel(re);
            Assert.AreEqual(icar.FuelAmount, icar.FuelCapacity);
        }

        [TestCase(100,50.5,45)]
        [TestCase(400,22,0)]
        [TestCase(900,50,0.5)]
        public void DriveMethodMustWorksFine(double distance, double refule, double expectedResult)
        {
            icar.Refuel(refule);
            icar.Drive(distance);
            //double fuelNeeded = (distance / 100) * this.FuelConsumption;
            
            Assert.AreEqual(icar.FuelAmount, expectedResult);
        }
        [TestCase(401, 22, 0)]
        public void DriveMethodMustReturnExeption(double distance, double refule, double expectedResult)
        {
            Assert.Throws<InvalidOperationException>(()=> icar.Drive(distance));
        }
    }
}