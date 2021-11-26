using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(null,10,200)]
        [TestCase("",10,200)]
        [TestCase("Name",-1,200)]
        [TestCase("Name",-100,200)]
        [TestCase("Name",0,200)]
        [TestCase("Name",10,-1)]
        [TestCase("Name",10,-100)]
        public void CreatingWarriorShuldReturnExeption(string name, int hitDmg, int HP)
        {
            Assert.Throws<ArgumentException>(()=>new Warrior(name,hitDmg,HP));
        }
        [TestCase("Name", 1, 0)]
        [TestCase("Name", 1, 10)]
        [TestCase("Name", 100, 1000)]
        public void CreatingWarriorShuldWorkFine(string name, int hitDmg, int HP)
        {
            Warrior warior = new Warrior(name, hitDmg, HP);
            Assert.AreEqual(name, warior.Name);
            Assert.AreEqual(hitDmg, warior.Damage);
            Assert.AreEqual(HP, warior.HP);

        }
        [TestCase(20)]
        [TestCase(30)]
        public void AttackingWithLessThanMinHPShuldReturnExeption(int HP)
        {
            Warrior hero1 = new Warrior("Tor", 100, HP);
            Warrior hero2 = new Warrior("Snake", 95, 600);

            Assert.Throws<InvalidOperationException>(() => hero1.Attack(hero2));

        }
        [TestCase(20)]
        [TestCase(30)]
        public void AttackingWithWarriorWithLessThanMinHpShuldReturnError(int hero2HP )
        {
            Warrior hero1 = new Warrior("Tor", 100, 300);
            Warrior hero2 = new Warrior("Snake", 95, hero2HP);

            Assert.Throws<InvalidOperationException>(() => hero1.Attack(hero2));

        }

        [TestCase(31,32)]
        [TestCase(300,350)]
        public void AttackingWariorAttacksAnotherWarirorWithHpLessThanWariorssDMG(int HP, int DMG)
        {
            Warrior hero1 = new Warrior("Tor", 100, HP);
            Warrior hero2 = new Warrior("Snake", DMG, 1000);

            Assert.Throws<InvalidOperationException>(() => hero1.Attack(hero2));

        }
        [TestCase(100, 1000,910,
                90,1200,1100)]
        [TestCase(100, 1000, 910,
                90, 90, 0)]

        public void AttackingWariorShuldWorkFine(int dmg1, int hp1, int resulthp1, int dmg2,int hp2, int resulthp2)
        {
            Warrior hero1 = new Warrior("Tor", dmg1, hp1);
            Warrior hero2 = new Warrior("Snake", dmg2, hp2);

            hero1.Attack(hero2);

            Assert.AreEqual(hero1.HP, resulthp1);
            Assert.AreEqual(hero2.HP, resulthp2);
        }
    }
}