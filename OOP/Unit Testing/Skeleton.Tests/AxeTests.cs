using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLooseDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints, 9);
        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => { axe.Attack(dummy); });
        }
    }
}