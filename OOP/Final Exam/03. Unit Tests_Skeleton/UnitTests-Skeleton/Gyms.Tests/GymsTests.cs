using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void creategymNullNameGYM()
        {           
            Assert.Throws<ArgumentNullException>(()=>new Gym("", 3));
            Assert.Throws<ArgumentNullException>(()=>new Gym(string.Empty, 3));
        }

        [Test]
        public void creategylessthan0gym()
        {
            Assert.Throws<ArgumentException>(() => new Gym("MusculeArt", -3));            
        }

        [Test]
        public void CreateGymShouldWokrOK()
        {
            Assert.DoesNotThrow(() => new Gym("MusculeArt", 0));
            Assert.DoesNotThrow(() => new Gym("MusculeArt1", 1));
            Assert.DoesNotThrow(() => new Gym("MusculeArt3", 10));
        }

        [Test]
        public void AthleteNewTest()
        {
            //Gym gym = new Gym("MusculeArt", 3);
            Athlete atlet = new Athlete("Joro");
            Assert.IsTrue(!atlet.IsInjured);
        }
        [Test]
        public void AddAthleteToGymAndCount()
        {
            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");

            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);

            Assert.AreEqual(2, gym.Count);
        }
        [Test]
        public void AddAthleteWhenIsFull()
        {
            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");
            Athlete atlet2 = new Athlete("Kiro");
            Athlete atlet3 = new Athlete("Iva");

            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);
            gym.AddAthlete(atlet2);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(atlet3));
        }

        [Test]
        public void RemoveAthleteNotExist()
        {
            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");
            Athlete atlet2 = new Athlete("Kiro");
            Athlete atlet3 = new Athlete("Iva");

            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);
            gym.AddAthlete(atlet2);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Iva"));
        }
        [Test]
        public void RemoveAthleteShuldWorkOk()
        {
            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");
            Athlete atlet2 = new Athlete("Kiro");


            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);
            gym.AddAthlete(atlet2);

            Assert.DoesNotThrow(() => gym.RemoveAthlete("Kiro"));
            Assert.AreEqual(2, gym.Count);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Kiro"));
        }

        [Test]
        public void InjureAthleteNotExist()
        {
            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");
            Athlete atlet2 = new Athlete("Kiro");


            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);
            gym.AddAthlete(atlet2);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Iva"));
        }
        [Test]
        public void InjureAthleteShouldWorkOk()
        {
            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");
            Athlete atlet2 = new Athlete("Kiro");


            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);
            gym.AddAthlete(atlet2);
            Assert.IsFalse(atlet.IsInjured);
            Assert.IsTrue(gym.InjureAthlete("Joro").IsInjured);
        }

        [Test]
        public void Report()
        {

            Gym gym = new Gym("MusculeArt", 3);

            Athlete atlet = new Athlete("Joro");
            Athlete atlet1 = new Athlete("Ivan");

            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet1);

            Assert.AreEqual("Active athletes at MusculeArt: Joro, Ivan", gym.Report());
        }
    }
}

