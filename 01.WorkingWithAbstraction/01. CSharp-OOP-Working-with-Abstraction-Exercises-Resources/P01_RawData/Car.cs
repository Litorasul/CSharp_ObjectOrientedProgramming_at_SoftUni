using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public Car(string model, int engineSpeed,
            int enginePower, int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age, double tire2Pressure,
            int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure,
            int tire4age)
        {
            Model = model;
            Engine = new Engine
            {
                EngineSpeed = engineSpeed,
                EnginePower = enginePower
            };
            Cargo = new Cargo
            {
                CargoWeight = cargoWeight,
                CargoType = cargoType
            };
            Tires = new Tire[4];

            Tires = GetTires(tire1Pressure, tire1Age, tire2Pressure,
           tire2Age, tire3Pressure, tire3age, tire4Pressure,
            tire4age);
        }

        private Tire[] GetTires(double tire1Pressure, int tire1Age, 
            double tire2Pressure, int tire2Age, double tire3Pressure, 
            int tire3age, double tire4Pressure, int tire4age)
        {
            Tire[] fourTires = new Tire[4];
            Tire tire1 = new Tire(tire1Pressure, tire1Age);
            fourTires[0] = tire1;
            Tire tire2 = new Tire(tire2Pressure, tire2Age);
            fourTires[1] = tire2;
            Tire tire3 = new Tire(tire3Pressure, tire3age);
            fourTires[2] = tire3;
            Tire tire4 = new Tire(tire4Pressure, tire4age);
            fourTires[3] = tire4;

            return fourTires;
        }
    }
}
