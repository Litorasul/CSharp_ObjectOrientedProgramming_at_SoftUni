using System.ComponentModel.DataAnnotations;

namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        private Phone phone;
        [SetUp]
        public void TestPhoneSetUp()
        {
            phone = new Phone("Nokia", "3310");
        }

        [Test]
        public void TestConstructorCorrectly()
        {
            string expectedMake = "Nokia";

            string actualMake = this.phone.Make;

            Assert.That(actualMake, Is.EqualTo(expectedMake));
        }

        [Test]
        public void TestMakeWithEmptyString()
        {
            string emptyMake = string.Empty;

            Assert.That(() => new Phone(emptyMake, "4"), Throws.ArgumentException);
        }

        [Test]
        public void TestModelWithEmptyString()
        {
            string emptyModel = string.Empty;

            Assert.That(() => new Phone("r", emptyModel), Throws.ArgumentException);
        }

        [Test]
        public void TestAddContactCorrectly()
        {
            this.phone.AddContact("K", "5");
            this.phone.AddContact("F", "4");
            this.phone.AddContact("E", "3");

            int expectedContacts = 3;
            int actualContacts = phone.Count;

            Assert.That(actualContacts, Is.EqualTo(expectedContacts));
        }

        [Test]
        public void TestAddContactAlreadyExists()
        {
            this.phone.AddContact("K", "5");

            Assert.That(() => this.phone.AddContact("K", "5"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestCallCorrestly()
        {
            this.phone.AddContact("K", "5");
            string expectedString = $"Calling K - 5...";

            string actualString = phone.Call("K");

            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void TestCallWithWrongContact()
        {
            this.phone.AddContact("K", "5");
            this.phone.AddContact("F", "4");
            this.phone.AddContact("E", "3");

            Assert.That(() => this.phone.Call("P"), Throws.InvalidOperationException);
        }
    }
}