using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        void Drive(double kilometers);
        void Refuel(double fuelAmmount);
    }
}
