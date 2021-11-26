using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        private List<Warrior> heros;
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            heros = new List<Warrior>();
            heros.Add(new Warrior("Tor", 120, 100));
            heros.Add(new Warrior("Snake", 90, 120));
            arena = new Arena();
            arena.Enroll(heros[0]);
            arena.Enroll(heros[1]);
        }

        [Test]
        public void CountShuldWorkFine()
        {
            Assert.AreEqual(arena.Count, 2);
        }
        [Test]
        public void WarriorsMethodShuldReturnListOfWarriors()
        {
            List<Warrior> returnWarriors = arena.Warriors.ToList();

            Assert.AreEqual(returnWarriors[0].Name, "Tor");
            Assert.AreEqual(returnWarriors.Count, 2);
        }
        [TestCase("Tor")]
        public void EnrollMethodShuldReturnErrorForExistingWarrior(string name)
        {
            Warrior curWarrior = new Warrior(name, 100, 100);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(curWarrior));
        }
        [TestCase("NewWarrior")]
        public void EnrollMethodShuldWorkFine(string name)
        {
            Warrior curWarrior = new Warrior(name, 100, 100);
            arena.Enroll(curWarrior);
            Assert.AreEqual(arena.Count, 3);
        }
        [TestCase("Tor","unKnown")]
        [TestCase("unKnown","Tor")]
        [TestCase("unKnown", "unKnown")]
        public void FightMethodShuldReturnExeptionForMissingWarrior(string name1, string name2)
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight(name1, name2));
        }

        [TestCase("Tor", "Snake")]
        public void FightMethodShuldWorkFine(string name1, string name2)
        {
            arena.Fight(name1, name2);

            List<Warrior> list = arena.Warriors.ToList();
            Assert.AreEqual(10, list[0].HP);
            Assert.AreEqual(0, list[1].HP);
        }
    }
}
