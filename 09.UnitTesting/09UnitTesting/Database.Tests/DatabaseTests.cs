using Database;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[] { 1, 2 });
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 2;

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestAddingCorrectly()
        {
            this.database.Add(3);
            int expectedCount = 3;

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestAddingOverTheLimit()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.That(() => database.Add(1),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }

        [Test]
        public void TestRemoveCorrectly()
        {
            int expectedCount = 1;

            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestRemoveFromEmptyDatabase()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void TestFetch()
        {
            int[] expected = new int[] { 1, 2 };
            int[] actual = this.database.Fetch();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}