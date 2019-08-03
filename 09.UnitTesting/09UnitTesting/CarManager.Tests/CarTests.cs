using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("VW", "Golf", 7.5, 70);
        }

        [Test]
        public void TestEmptyConstructor()
        {
            double fuelAmmountExpected = 0;
            double fuelAmmountActual = this.car.FuelAmount;

            Assert.That(fuelAmmountActual, Is.EqualTo(fuelAmmountExpected));
        }

        [Test]
        public void TestMakeWithNull()
        {
            string emptyMake = string.Empty;

            Assert.That(() => new Car(emptyMake, "f", 3, 130), Throws.ArgumentException
                .With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void TestModelWithNull()
        {
            string emptyModel = string.Empty;

            Assert.That(() => new Car("f", emptyModel, 3, 130), Throws.ArgumentException
                .With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void TestNegativeFuelConsumption()
        {
            Assert.That(() => new Car("f", "d", -3.3, 130), Throws.ArgumentException
               .With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void TestNegativeFuelCapacity()
        {
            Assert.That(() => new Car("f", "d", 3, -130), Throws.ArgumentException
               .With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void TestRefuelCorrectly()
        {
            car.Refuel(30.5);
            double expectedFuelAmmount = 30.5;
            double actualFuelAmmount = car.FuelAmount;

            Assert.That(actualFuelAmmount, Is.EqualTo(expectedFuelAmmount));
        }

        [Test]
        public void TestNegativeRefuel()
        {
            Assert.That(() => car.Refuel(-20.4), Throws.ArgumentException
               .With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void TestRefuelOverTheCapacity()
        {
            double expectedFuelAmmount = car.FuelCapacity;
            car.Refuel(200);
            double actualFuelAmmount = car.FuelAmount;

            Assert.That(actualFuelAmmount, Is.EqualTo(expectedFuelAmmount));
        }

        [Test]
        public void TestDriveCorrectly()
        {
            car.Refuel(15);
            car.Drive(100);
            double expectedFuelAmmount = 7.5;
            double actualFuelAmmount = car.FuelAmount;

            Assert.That(actualFuelAmmount, Is.EqualTo(expectedFuelAmmount));
        }

        [Test]
        public void TestDriveNotEnoughFuel()
        {
            car.Refuel(7.5);

            Assert.That(() => car.Drive(200), Throws.InvalidOperationException
               .With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}