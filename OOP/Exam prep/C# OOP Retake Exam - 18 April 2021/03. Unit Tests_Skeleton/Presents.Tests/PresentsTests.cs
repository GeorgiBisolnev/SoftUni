namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CreatePresent()
        {
            var present = new Present("Nike", 1.5);
            var present1 = new Present("Adi", 2);

            var bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            Assert.AreEqual(2, bag.GetPresents().Count);

        }
        [Test]
        public void CreatePresentNullException()
        {
            var present = new Present("Nike", 1.5);
            var present1 = new Present("Adi", 2);

            var bag = new Bag();

            bag.Create(present);
            
            present1 = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present1));

        }
        [Test]
        public void CreatePresentAlreadyExsistsExcaption()
        {
            var present = new Present("Nike", 1.5);
            var present1 = new Present("Adi", 2);

            var bag = new Bag();

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));

        }
        [Test]
        public void remove()
        {
            var present = new Present("Nike", 1.5);
            var present1 = new Present("Adi", 2);

            var bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            Assert.IsTrue(bag.Remove(present));
            Assert.IsFalse(bag.Remove(present));

        }
        [Test]
        public void GetPresentWithLeastMagicShuldWorkFine()
        {
            var present = new Present("Nike", 1.5);
            var present1 = new Present("Adi", 2);

            var bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            var newPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual("Nike", newPresent.Name);
            Assert.AreEqual(1.5, newPresent.Magic);
        }
        [Test]
        public void getPresentShoudlworkOk()
        {
            var present = new Present("Nike", 1.5);
            var present1 = new Present("Adi", 2);

            var bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            var newPresent = bag.GetPresent("Nike");

            Assert.AreEqual("Nike", newPresent.Name);
            Assert.AreEqual(1.5, newPresent.Magic);

        }
    }
}
