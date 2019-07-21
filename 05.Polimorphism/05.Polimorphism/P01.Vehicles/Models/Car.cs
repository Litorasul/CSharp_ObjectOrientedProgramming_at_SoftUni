using P01.Vehicles.Contracts;
using System;

namespace P01.Vehicles.Models
{
    public class Car : IVehicle
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
                    throw new ArgumentException("Car needs refueling");
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
                this.fuelConsumption = value + 0.9;
            }
        }

        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public void Drive(double kilometers)
        {
            if ((this.FuelQuantity - (this.FuelConsumption * kilometers)) < 0)
            {
                throw new ArgumentException("Car needs refueling");
            }
            this.FuelQuantity -= this.FuelConsumption * kilometers;
            Console.WriteLine($"Car travelled {kilometers} km");
        }

        public void Refuel(double fuelAmmount)
        {
            if (fuelAmmount < 0)
            {
                throw new ArgumentException();
            }
            this.FuelQuantity += fuelAmmount;
        }

        public override string ToString()
        {
            return $"Car: { this.FuelQuantity:F2}";
        }
    }
}
