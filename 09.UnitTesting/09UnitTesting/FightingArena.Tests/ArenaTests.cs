using FightingArena;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;

        [SetUp]
        public void Setup()
        {
            Warrior pesho = new Warrior("Pesho", 6, 40);
            Warrior gosho = new Warrior("Gosho", 5, 45);
            arena = new Arena();
            arena.Enroll(pesho);
            arena.Enroll(gosho);
        }

        [Test]
        public void TestCountCorrectly()
        {
            int expectedCount = 2;
            int actualCount = arena.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestEnrollCorrectly()
        {
            string expectedName = "Pesho";
            string actualName = arena.Warriors.Where(w => w.HP == 40).FirstOrDefault().Name;

            Assert.That(actualName, Is.EqualTo(expectedName));
        }

        [Test]
        public void TestEnrollAlreadyEnrolled()
        {
            Warrior peshoAgain = new Warrior("Pesho", 6, 40);

            Assert.That(() => arena.Enroll(peshoAgain), Throws.InvalidOperationException
                .With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void TestFightCorrectly()
        {
            int expectedHP = 35;

            arena.Fight("Gosho", "Pesho");
            int actualHP = arena.Warriors.Where(w => w.Name == "Pesho").FirstOrDefault().HP;

            Assert.That(actualHP, Is.EqualTo(expectedHP));
        }

        [Test]
        public void TestFightWrongAttacker()
        {
            Assert.That(() => arena.Fight("Frank", "Gosho"), Throws.InvalidOperationException
                .With.Message.EqualTo("There is no fighter with name Frank enrolled for the fights!"));
        }

        [Test]
        public void TestFightWrongDefender()
        {
            Assert.That(() => arena.Fight("Gosho", "Frank"), Throws.InvalidOperationException
                .With.Message.EqualTo("There is no fighter with name Frank enrolled for the fights!"));
        }
    }
}

