using P01.Vehicles.Contracts;
using System;

namespace P02.VehicleExtension.Models
{
    public abstract class Vehicle : IVehicle
    {        
        private double fuelQuantity;
        private double fuelConsumption;
        public virtual double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{this.GetType().Name} needs refueling");
                }
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                
                this.fuelConsumption = value;
            }
        }

        public double TankCapacity { get; }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            if (fuelQuantity > tankCapacity)
            {               
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumption = fuelConsumption;
            
        }

        public virtual void Drive(double kilometers)
        {
            if ((this.FuelQuantity - (this.FuelConsumption * kilometers)) < 0)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= this.FuelConsumption * kilometers;
            Console.WriteLine($"{this.GetType().Name} travelled {kilometers} km");
        }

        public virtual void Refuel(double fuelAmmount)
        {
            if (fuelAmmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuelAmmount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmmount} fuel in the tank");
            }
            this.FuelQuantity += fuelAmmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
