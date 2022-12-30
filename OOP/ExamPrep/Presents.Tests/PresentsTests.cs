using System.Collections.Generic;
using System.Linq;

namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        //CREATE
        [Test]
        public void CreateWork()
        {
            Present present = new Present("Pepi", 4.5);
            Bag bag = new Bag();
            Assert.AreEqual($"Successfully added present {present.Name}.", bag.Create(present));
        }

        [Test]
        public void CantCreateNullPresent()
        {
            Present present = null;
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CantAddExistingItem()
        {
            Present present1 = new Present("Pepi", 4.5);

            Bag bag = new Bag();
            bag.Create(present1);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present1));
        }

        //REMOVE
        [Test]
        public void RemoveWork()
        {
            Present present = new Present("Pepi", 4.5);
            Bag bag = new Bag();

            bag.Create(present);
            Assert.True(bag.Remove(present));
        }

        //GET THE LOWEST MAGIC ITEM
        [Test]
        public void LowestMagicPower()
        {
            Present present1 = new Present("Pepi", 4.5);
            Present present2 = new Present("Koki", 7.9);

            Bag bag = new Bag();
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(present1, bag.GetPresentWithLeastMagic());
        }

        //Get present
        [Test]
        public void GetPresent()
        {
            Present present = new Present("Pepi", 4.5);
            Bag bag = new Bag();

            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent("Pepi"));
        }

        //Return Collection
        [Test]
        public void ReturnRightThing()
        {
            List<Present> presents = new List<Present>();
            Bag bag = new Bag();

            Present present = new Present("Pepi", 2.4);
            presents.Add(present);
            bag.Create(present);

            Assert.AreEqual(presents.AsReadOnly().Count, bag.GetPresents().Count);
        }
    }
}
