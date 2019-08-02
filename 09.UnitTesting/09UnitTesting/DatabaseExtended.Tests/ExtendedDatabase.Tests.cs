using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        Person person;
        ExtendedDatabase.ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
             person = new Person(1, "Pesho");
            database = new ExtendedDatabase.ExtendedDatabase(person);

        }

        [Test]
        public void TestPersonConstructorId()
        {
            long expectedId = 1;

            Assert.That(this.person.Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void TestPersonConstructorName()
        {
            string expectedName = "Pesho";

            Assert.That(this.person.UserName, Is.EqualTo(expectedName));
        }

        [Test]
        public void TestDatabaseConstructorCorrectly()
        {
            int expectedCount = 1;

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestAddRangeOverTheLimits()
        {
            Person[] people = new Person[17];
            for (int i = 1; i < 17; i++)
            {
                people[i] = new Person(i, $"P{i}");
            }

            Assert.That(() => database = new ExtendedDatabase.ExtendedDatabase(people),
                Throws.ArgumentException.With.Message
                .EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void TestAddCorrectly()
        {
            int expectedCount = 2;
            Person person = new Person(2, "P2");
            database.Add(person);

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestAddOverTheLimit()
        {
            for (int i = 2; i <= 16; i++)
            {
                database.Add(new Person(i + 1, $"P{i}"));
            }
            Person person = new Person(33, "K");

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void TestAddSameUsername()
        {
            Person person = new Person(2, "Pesho");

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException
                .With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void TestAddSameId()
        {
            Person person = new Person(1, "Gosho");

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException
                .With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void TestRemoveCorrectly()
        {
            int expectedCount = 0;
            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestRemoveFromEmptyDatabase()
        {
            this.database.Remove();

            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFindByUsernameCorrectly()
        {
            long expectedId = 1;
            long actualId = database.FindByUsername("Pesho").Id;

            Assert.That(actualId, Is.EqualTo(expectedId));
        }

        [Test]
        public void TestFindByUsernameEmptyParameter()
        {
            string testString = string.Empty;

            Assert.That(() => this.database.FindByUsername(testString),
                Throws.ArgumentNullException);
        }

        [Test]
        public void TestFindByUsernameIncorrectUsername()
        {
            Assert.That(() => this.database.FindByUsername("Gosho"),
                Throws.InvalidOperationException
                .With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void TestFindByIdCorrectly()
        {
            string expectedName = "Pesho";
            string actualname = this.database.FindById(1).UserName;

            Assert.That(actualname, Is.EqualTo(expectedName));
        }

        [Test]
        public void TestFindByIdNegativeParameter()
        {
            int parameter = -3;

            Assert.That(() => this.database.FindById(parameter),
                Throws.TypeOf<ArgumentOutOfRangeException>());    
        }

        [Test]
        public void TestFindByIdIncorrectId()
        {
            Assert.That(() => this.database.FindById(3),
                Throws.InvalidOperationException.With.Message
                .EqualTo("No user is present by this ID!"));
        }
    }
}