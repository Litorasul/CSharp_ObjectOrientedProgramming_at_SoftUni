using System;

namespace P02.VehicleExtension.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 1.6;
        }

        public override void Refuel(double fuelAmmount)
        {
            double ammount = fuelAmmount * 0.95;
            if (fuelAmmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuelAmmount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmmount} fuel in the tank");
            }
            this.FuelQuantity += ammount;
        }
    }
}
