namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Database database;
        Person person;
        Person person1;

        //ADD METHOD
        [Test]
        public void AlredyHaveThisID()
        {
            database = new Database();
            person = new Person(123123, "Pesho");
            database.Add(person);
            person1 = new Person(123123, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person1);
            });
        }

        [Test]
        public void AlredyHaveThisUsername()
        {
            database = new Database();
            person = new Person(123, "Pesho");
            person1 = new Person(321, "Pesho");
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person1);
            });
        }

        [Test]
        public void CountShouldBeOne()
        {
            database = new Database();
            database.Add(person);

            int countToCheck = 1;

            Assert.AreEqual(countToCheck, database.Count);
        }

        [Test]
        public void OverLoadTheDataBase()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, "K" + i);
                persons.Add(person);
            }
            database = new Database(persons.ToArray());

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person1 = new Person(123, "Kosio"));
            });
        }

        //REMOVE METHOD
        [Test]
        public void CantRemoveEmptyArrayOfPersons()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void CountGoesDownIfRemove()
        {
            database = new Database();
            person = new Person(123, "Pesho");
            database.Add(person);
            database.Remove();

            Assert.AreEqual(database.Count, 0);
        }

        //FIND BY USERNAME METHOD
        [Test]
        public void ArrayDontContainUsername()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("GOSHO");
            });
        }

        [Test]
        public void UsernameCantBeNull()
        {
            database = new Database();

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        //FIND BY ID METHOD
        [Test]
        public void ArrayDontContainID()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(123);
            });
        }

        [Test]
        public void IDCantBeNull()
        {
            database = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-123);
            });
        }

        //RETURN RIGHT INFO
        [Test]
        public void FindByUsernameReturnsCorrectPerson()
        {
            database = new Database();
            person = new Person(123, "A");
            database.Add(person);

            Assert.AreEqual(database.FindByUsername("A").UserName, "A");
        }

        [Test]
        public void FindByIDReturnsCorrectPerson()
        {
            database = new Database();
            person = new Person(123, "A");
            database.Add(person);

            Assert.AreEqual(database.FindById(123).Id, 123);
        }
    }
}