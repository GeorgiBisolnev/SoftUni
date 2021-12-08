namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        Aquarium myAquarium;
        Fish fish1,fish2;

        [SetUp]
        public void SetUp()
        {
            myAquarium = new Aquarium("SweetWater", 3);
            fish1 = new Fish("Fizz");
            fish2 = new Fish("GoldFish");
        }
        [Test]
        public void newAquariumNullexception()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 2));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 2));

        }
        [Test]
        public void newAquariumCapacityExceptionWhenLessthanZero()
        {

            Assert.Throws<ArgumentException>(() => new Aquarium("Aqua", -1));
        }
        [Test]
        public void newAquariumShouldWorkFine()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);
            Assert.AreEqual(2, myAquarium.Count);
        }
        [Test]
        public void whenAquariumisfullReturnException()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);
            Fish newFish = new Fish("anotherFish");
            Fish newFish1 = new Fish("anotherFish1");
            myAquarium.Add(newFish);
            Assert.Throws<InvalidOperationException>(() => myAquarium.Add(newFish1));
        }
        [Test]
        public void RemoveFishException()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => myAquarium.RemoveFish("noNameFish"));
        }
        [Test]
        public void RemoveFish()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);
            myAquarium.RemoveFish("GoldFish");
            Assert.AreEqual(1, myAquarium.Count);
        }

        [Test]
        public void SellFishException()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() => myAquarium.SellFish("NoName"));
        }
        [Test]
        public void SellFish()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);
            Assert.IsFalse(myAquarium.SellFish("Fizz").Available);
        }

        [Test]
        public void Report()
        {

            myAquarium.Add(fish1);
            myAquarium.Add(fish2);
            Assert.AreEqual("Fish available at SweetWater: Fizz, GoldFish", myAquarium.Report());
        }
    }
}
