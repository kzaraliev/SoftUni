using NUnit.Framework;

namespace UnitTestingTest
{
    public class Tests
    {
        private int x = 0;
        [SetUp]
        public void SetUp()
        {
            x = 55;
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(1, x, "1 + 5 should equal to 6"); 
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(2, x, "1 + 5 should equal to 7");
        }

        [TearDown]
        public void CleanUp()
        {

        }
    }
}