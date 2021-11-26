using NUnit.Framework;
using System;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void AddIntToDataBase()
        {
            Database data = new Database();
            data.Add(10);
            data.Add(10);
            data.Add(10);

            Assert.AreEqual(3, data.Count);
        }

        [Test]
        public void ThrowExIfLongerThan16()
        {
            Database data = new Database();
            for (int i = 0; i < 16; i++)
            {
                data.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => data.Add(5));
        }

        [Test]
        [TestCase(1, 4)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void Inster15Elements(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database data = new Database(elements);

            Assert.AreEqual(count, data.Count);

        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        [TestCase(1, 100)]
        public void ConstructorShuldThrolExWhenCountAbove16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }
        [Test]
        public void RemoveMethodShuldRemoveElementWhenCountAbove0()
        {
            int[] elements = Enumerable.Range(1, 15).ToArray();
            Database data = new Database(elements);

            data.Remove();

            Assert.AreEqual(14, data.Count);
        }

        [Test]
        public void RemoveMethodShuldRemoveCorrectElement()
        {
            int[] array = new int[] {1,2,3,4};

            Database data = new Database(array);

            data.Remove();
            Assert.AreEqual(3, array[data.Count-1]);
        }

        [Test]
        public void RemoveMethodShuldThrowExIfelementCountisZero()
        {
            int[] array = new int[] { 1 };

            Database data = new Database(array);

            data.Remove();
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void FetchMethodShuldreturnElementsAsArray()
        {
            int[] array = new int[] { 1,2,3,4 };

            Database data = new Database(array);

            Assert.AreEqual(array,data.Fetch());
        }
    }
}