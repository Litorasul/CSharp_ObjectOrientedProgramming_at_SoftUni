using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 5, 40);
        }

        [Test]
        public void TestNameCorrectly()
        {
            string expectedName = "Pesho";
            string actualName = warrior.Name;

            Assert.That(actualName, Is.EqualTo(expectedName));
        }

        [Test]
        public void TestNameWithWhiteSpace()
        {
            string nameWhiteSpace = " ";

            Assert.That(() => new Warrior(nameWhiteSpace, 3, 22), Throws.ArgumentException
                .With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void TestDamageCorrectly()
        {
            int expectedDamage = 5;
            int actualDamage = warrior.Damage;

            Assert.That(actualDamage, Is.EqualTo(expectedDamage));
        }

        [Test]
        public void TestNegativeDamage()
        {
            Assert.That(() => new Warrior("g", -3, 22), Throws.ArgumentException
                .With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void TestHPCorrectly()
        {
            int expestedHP = 40;
            int actualHP = warrior.HP;

            Assert.That(actualHP, Is.EqualTo(expestedHP));
        }

        [Test]
        public void TestNegativeHP()
        {
            Assert.That(() => new Warrior("k", 3, -22), Throws.ArgumentException
                .With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void TestAttackCorrectlyAttackerHP()
        {
            Warrior defender = new Warrior("defender", 6, 40);
            int expectedHP = 35;

            warrior.Attack(defender);
            int actualHP = defender.HP;

            Assert.That(actualHP, Is.EqualTo(expectedHP));
        }

        [Test]
        public void TestAttackCorrectlyDefenderHP()
        {
            Warrior defender = new Warrior("defender", 6, 40);
            int expectedHP = 34;

            warrior.Attack(defender);
            int actualHP = warrior.HP;

            Assert.That(actualHP, Is.EqualTo(expectedHP));
        }

        [Test]
        public void TestAttackWithAttackerLowHP()
        {
            Warrior attacker = new Warrior("attacker", 6, 20);

            Assert.That(() => attacker.Attack(warrior), Throws.InvalidOperationException
                .With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void TestAttackWithDefenderLowHP()
        {
            Warrior defender = new Warrior("defender", 6, 20);

            Assert.That(() => warrior.Attack(defender), Throws.InvalidOperationException
               .With.Message.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void TestAttackWithStrongEnemy()
        {
            Warrior defender = new Warrior("defender", 55, 40);

            Assert.That(() => warrior.Attack(defender), Throws.InvalidOperationException
               .With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void TestAttackWhenKill()
        {
            Warrior attacker = new Warrior("attacker", 50, 40);
            int expectedHP = 0;

            attacker.Attack(warrior);
            int actualHP = warrior.HP;

            Assert.That(actualHP, Is.EqualTo(expectedHP));
            

        }
    }
}