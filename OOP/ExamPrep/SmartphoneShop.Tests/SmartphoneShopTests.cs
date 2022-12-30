using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        Shop shop;
        //Add
        [Test]
        public void AddMethodWorkCorrectly()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(10);

            shop.Add(smartphone);
            Assert.AreEqual(shop.Count, 1);
        }

        [Test]
        public void CantAddExistingPhone()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Shop shop = new Shop(10);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException> (() => shop.Add(smartphone1));
        }

        [Test]
        public void ShopHasReachedHisMaxCapacity()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Smartphone smartphone1 = new Smartphone("Samsung", 10);
            Shop shop = new Shop(1);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1));
        }

        //Remove method 
        [Test]
        public void RemoveWorkCorrectly()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(10);

            shop.Add(smartphone);
            shop.Remove("Nokia");

            Assert.AreEqual(shop.Count, 0);
        }

        [Test]
        public void CantRemoveUnexistingPhone()
        {
            Shop shop = new Shop(10);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Nokia"));
        }

        //TestPhone method
        [Test]
        public void CantTestPhoneUnexisting()
        {
            Shop shop = new Shop(10);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 10));
        }

        [Test]
        public void PhoneHasNotEnoughBattery()
        {
            Shop shop = new Shop(19);
            Smartphone smartphone = new Smartphone("Nokia", 0);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 10));
        }

        [Test]
        public void TestPhoneWork()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(19);

            shop.Add(smartphone);
            shop.TestPhone("Nokia", 10);

            Assert.AreEqual(smartphone.CurrentBateryCharge, 90);
        }

        //ChargePhone method
        [Test]
        public void ChargePhoneWork()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(19);

            shop.Add(smartphone);
            shop.TestPhone("Nokia", 100);
            shop.ChargePhone("Nokia");

            Assert.AreEqual(smartphone.CurrentBateryCharge, 100);
        }

        [Test]
        public void CantChargeUnexistingPhone()
        {
            Shop shop = new Shop(19);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Nokia"));
        }

        //Capacity
        [Test]
        public void CapacityCantBeUnderZero()
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));
        }
    }
}