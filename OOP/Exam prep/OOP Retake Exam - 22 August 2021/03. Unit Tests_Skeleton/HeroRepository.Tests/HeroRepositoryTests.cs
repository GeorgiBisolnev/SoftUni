using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [SetUp]
    public void SetUp()
    {

    }
    [Test]
    public void CreateNullHeroShuldReturnExcepton()
    {
        var hero = new Hero("12",12);
        var heroRep = new HeroRepository();
        hero = null;

        Assert.Throws<ArgumentNullException>(() => heroRep.Create(hero));
    }
    [Test]
    public void Createalreadyexists()
    {
        var hero = new Hero("12", 12);
        var heroRep = new HeroRepository();
        heroRep.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRep.Create(hero));
    }

    [Test]
    public void CreateHero()
    {
        var hero = new Hero("12", 12);
        var hero1 = new Hero("123", 12);
        var heroRep = new HeroRepository();
        heroRep.Create(hero);
        heroRep.Create(hero1);

        Assert.AreEqual(2, heroRep.Heroes.Count);
    }
    [Test]
    public void remove()
    {
        var hero = new Hero("12", 12);
        var hero1 = new Hero("123", 12);
        var heroRep = new HeroRepository();
        heroRep.Create(hero);
        heroRep.Create(hero1);
        heroRep.Remove(hero1.Name);

        Assert.AreEqual(1, heroRep.Heroes.Count);
        Assert.IsNotNull(heroRep.Heroes.FirstOrDefault(x => x.Name == "12"));
    }

    [Test]
    public void removenameCantBeNull()
    {
        var hero = new Hero("12", 12);
        var hero1 = new Hero("123", 12);
        var heroRep = new HeroRepository();
        heroRep.Create(hero);
        heroRep.Create(hero1);

        Assert.Throws<ArgumentNullException>(()=> heroRep.Remove(null));

    }
    [Test]
    public void getHighestLvHero()
    {
        var hero = new Hero("12", 12);
        var hero1 = new Hero("123", 13);
        var heroRep = new HeroRepository();
        heroRep.Create(hero);
        heroRep.Create(hero1);
        var hlhero = heroRep.GetHeroWithHighestLevel();
        Assert.AreEqual(13, hlhero.Level);

    }
    [Test]
    public void getHero()
    {
        var hero = new Hero("12", 12);
        var hero1 = new Hero("123", 13);
        var heroRep = new HeroRepository();
        heroRep.Create(hero);
        heroRep.Create(hero1);

        var newHero = heroRep.GetHero("12");
        Assert.AreEqual("12", newHero.Name);
        Assert.AreEqual(12, newHero.Level);

        newHero = heroRep.GetHero("122");
        Assert.IsNull(newHero);


    }

}