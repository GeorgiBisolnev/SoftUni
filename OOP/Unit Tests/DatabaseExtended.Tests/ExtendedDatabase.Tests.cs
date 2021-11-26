using NUnit.Framework;

using System;

namespace ExtendedDatabase.Tests
{
    public class Tests
    {
        private Person personJoro;
        private ExtendedDatabase ed;
        

        [SetUp]
        public void Setup()
        {
            this.personJoro = new Person(1, "Georgi");
           ed = new ExtendedDatabase(
            new Person(1, "Alfa"),
             new Person(2, "Beta"),
              new Person(3, "Gama"),
               new Person(4, "Delta"),
                new Person(5, "Epsilon"),
                 new Person(6, "Zeta"),
                  new Person(7, "Eta"),
                   new Person(8, "Teta"),
                    new Person(9, "Jota"),
                     new Person(10, "Kapa"),
                      new Person(11, "Lambda"),
                       new Person(12, "Mu"),
                        new Person(13, "Nu"),
                         new Person(14, "Ksi"),
                          new Person(15, "Omikron")

            );

    }
        [Test]
        public void Count_ShouldReturnInternalArrayCount()
        {


            Assert.AreEqual(15, ed.Count);
        }


        [Test]
        public void ConstructorExtendedDatabaseTest()
        {
            ExtendedDatabase ednew = new ExtendedDatabase(new Person(1, "asd"));

            Assert.AreEqual(1, ednew.Count);
        }

        [Test]
        public void AddRangeTest()
        {
            Assert.AreEqual(15, ed.Count);
        }

        [Test]

        public void AddRangeShuldReturnExIfPersonsAbove16()
        {
            ExtendedDatabase ednew = new ExtendedDatabase();
            Person[] persons = new Person[] {
            new Person(1, "Alfa"),
             new Person(2, "Beta"),
              new Person(3, "Gama"),
               new Person(4, "Delta"),
                new Person(5, "Epsilon"),
                 new Person(6, "Zeta"),
                  new Person(7, "Eta"),
                   new Person(8, "Teta"),
                    new Person(9, "Jota"),
                     new Person(10, "Kapa"),
                      new Person(11, "Lambda"),
                       new Person(12, "Mu"),
                        new Person(13, "Nu"),
                         new Person(14, "Ksi"),
                          new Person(15, "Omikron"),
                            new Person(16, "Another guy"),
                                new Person(17, "Another guy Err")

            };

            Assert.Throws<ArgumentException>(() => ednew = new ExtendedDatabase(persons));
        }

        [Test]
        public void AddpersonshuldThrowEx()
        {

            ed.Add(new Person(16, "Putin"));


            Assert.Throws<InvalidOperationException>(()=> ed.Add(new Person(17, "Trump")));


        }
        [Test]
        public void AddpersonshuldThrowExDoubleNameInput()
        {

            Assert.Throws<InvalidOperationException>(() => ed.Add(new Person(16, "Alfa")));


        }

        [Test]
        public void AddMethod_ShouldThrowExceptionWhenTryingToAddMorePersonsThanMaxCapacity()
        {

            ed.Add(new Person(16, "Putin"));


            Assert.Throws<InvalidOperationException>(() => ed.Add(new Person(17, "Putin")));


        }
        [Test]
        public void AddMethodShuldWorkProperly()
        {
            ed.Add(new Person(16, "Ahmed"));
            Assert.AreEqual(16, ed.Count);

        }

        [Test]
        public void AddpersonshuldThrowExDoubleId()
        {

            ed.Add(new Person(16, "Putin"));


            Assert.Throws<InvalidOperationException>(() => ed.Add(new Person(16, "Putin1")));


        }
        [Test]
        public void RemoMethindShuldRemoveOnePerson()
        {

            ed.Remove();


            Assert.AreEqual(14, ed.Count);


        }

        [Test]
        public void RemoMethondShuldRetunrExRemovingFrom0Count()
        {
            for (int i = 0; i < 15; i++)
            {
                ed.Remove();
            }
            Assert.Throws<InvalidOperationException>(()=>ed.Remove());

            ExtendedDatabase ednew = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => ednew.Remove());
        }

        [Test]
        public void FindusernameshuldretunrPerson()
        {
            Person person = ed.FindByUsername("Alfa");
            Assert.AreEqual(person.UserName, "Alfa");
            Assert.AreEqual(person.Id, 1);
        }

        [TestCase("")]
        [TestCase(null)]

        public void FindByUsernameshuldreturnexfornullparameter(string par)
        {
            Assert.Throws<ArgumentNullException>(()=> ed.FindByUsername(par));        
        }

        [TestCase("unknown")]
        [TestCase("na")]
        public void FindByUsernameshuldreturnexforunknownusername(string par)
        {
            Assert.Throws<InvalidOperationException>(() => ed.FindByUsername(par));
        }

        public void FinduserbyID()
        {
            Person person = ed.FindById(1);

            Assert.AreEqual(person.Id, 1);
            Assert.AreEqual(person.UserName, "Alfa");
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void FindUsernameByIDShuldRetunExifidlessthan0(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ed.FindById(id));
        }

        [TestCase(17)]
        [TestCase(500)]
        public void FindUsernameByIDShuldRetunExifidnotpresent(long id)
        {
            Assert.Throws<InvalidOperationException>(() => ed.FindById(id));
        }

    }
}