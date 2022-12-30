namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] arrayWithMoreThan16Lenght = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        private int[] arrayWith16Lenght = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int[] arrayWithLengthBelow16 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Test]
        public void Test_ConstructorShouldSetTheFieldsProperyWithLengh16()
        {
            database = new Database(arrayWith16Lenght);
            Assert.That(database.Count, Is.EqualTo(arrayWith16Lenght.Length));
        }

        [Test]
        public void Test_ConstructorShouldThrowExceptionIfLenghtIsOver16()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(arrayWithMoreThan16Lenght);
            });
        }

        [Test]
        public void Test_AddShouldIncreceCount()
        {
            database = new Database(arrayWithLengthBelow16);

            database.Add(6);
            var count = 11; //Corrected from database.Count;

            Assert.That(database.Count, Is.EqualTo(count));
        }

        [Test]
        public void Test_AddShouldThrowExceptionIfLenthIs16()
        {
            database = new Database(arrayWith16Lenght);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(10);
            });
        }

        [Test]
        public void Test_RemoveShouldDecreaceCountEachTime()
        {
            database = new Database(arrayWithLengthBelow16);

            database.Remove();
            var count = 9; //Corrected from database.Count;

            Assert.That(database.Count, Is.EqualTo(count));
        }

        [Test]
        public void Test_RemoveShouldTrhowExceptionIfDatabaseIsEmpty()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Test_FetchShouldReturnCopyOfTheArray()
        {
            database = new Database(arrayWithLengthBelow16);
            int[] copy = database.Fetch();

            Assert.That(arrayWithLengthBelow16, Is.EqualTo(copy));
        }
    }
}
