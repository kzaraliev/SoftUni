using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 10);

            axe.Attack(dummy);
            Assert.AreEqual(90, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => { axe.Attack(dummy); });
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.AreEqual(dummy.GiveExperience(), 10);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => { dummy.GiveExperience(); });
        }
    }
}