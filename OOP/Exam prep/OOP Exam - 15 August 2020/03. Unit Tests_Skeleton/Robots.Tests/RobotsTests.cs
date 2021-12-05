namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot,robot1;
        RobotManager robManager;
        [SetUp]
        public void Setup()
        {
            robot = new Robot("Robi", 100);
            robot1 = new Robot("BigRobo", 150);
            robManager = new RobotManager(3);
            robManager.Add(robot);
            robManager.Add(robot1);
        }
        [Test]
        public void RobotManagerCapaciti()
        {
            Assert.AreEqual(3, robManager.Capacity);
        }
        [Test]
        public void RobotManagerCapacitiError()
        {

            Assert.Throws<ArgumentException>(()=>new  RobotManager(-2));
        }
        [Test]
        public void RobotManagerCount()
        {

            Assert.AreEqual(2,robManager.Count);
        }

        [Test]
        public void RobotManagerErrorDoubleNames()
        {
            Robot anotherRobot=new Robot("Robi", 50);
            Assert.Throws<InvalidOperationException>(()=>robManager.Add(anotherRobot));
        }
        [Test]
        public void RobotManagerErrorCapacity()
        {
            Robot anotherRobot = new Robot("Koko", 50);
            robManager.Add(anotherRobot);
            Robot anotherRobot1 = new Robot("Amumu", 50);
            Assert.Throws<InvalidOperationException>(() => robManager.Add(anotherRobot1));
        }
        [Test]
        public void RobotManagerRemoveError()
        {
            Assert.Throws<InvalidOperationException>(() => robManager.Remove("Amumu"));
        }

        [Test]
        public void RobotManagerRemove()
        {
            robManager.Remove("Robi");
            Assert.AreEqual(1, robManager.Count);           
        }
        [Test]
        public void RobotManagerWork()
        {
            robot.Battery = 100;

            robManager.Work("Robi", "PLay", 100);
            Assert.AreEqual(0, robot.Battery);
        }
        [Test]
        public void RobotManagerWorkShuldReturnErrWhenNoRobotNameIsFound()
        {
            robot.Battery = 100;

            Assert.Throws<InvalidOperationException>(() => robManager.Work("Robii", "PLay", 100));
        }
        [Test]
        public void RobotManagerWorkShuldReturnErrWhenNoEounghBattery()
        {
            robot.Battery = 100;

            Assert.Throws<InvalidOperationException>(() => robManager.Work("Robi", "PLay", 101));
        }
        [Test]
        public void RobotManagerChargeShuldReturnErrWhenNoRobotIsFound()
        {            
            Assert.Throws<InvalidOperationException>(() => robManager.Charge("Robii"));
        }
        [Test]
        public void RobotManagerCharge()
        {
            robot.Battery = 0;
            robManager.Charge("Robi");
            Assert.AreEqual(100, robot.Battery);
        }
    }
}
