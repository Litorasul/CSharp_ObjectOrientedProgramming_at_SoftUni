using P01.Vehicles.Contracts;
using System;

namespace P01.Vehicles.Models
{
    public class Truck : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Truck needs refueling");
                }
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.fuelConsumption = value + 1.6;
            }
        }

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public void Drive(double kilometers)
        {
            if ((this.FuelQuantity - (this.FuelConsumption * kilometers)) < 0)
            {
                throw new ArgumentException("Truck needs refueling");
            }
            this.FuelQuantity -= this.FuelConsumption * kilometers;
            Console.WriteLine($"Truck travelled {kilometers} km");
        }

        public void Refuel(double fuelAmmount)
        {
            if (fuelAmmount < 0)
            {
                throw new ArgumentException();
            }
            this.FuelQuantity += fuelAmmount * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:F2}";
        }
    }
}
