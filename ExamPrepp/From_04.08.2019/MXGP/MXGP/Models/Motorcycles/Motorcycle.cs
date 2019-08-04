using MXGP.Models.Motorcycles.Contracts;
using System;


namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle, IRepositorable
    {
        private string model;
        private int horsePower;
        
        public string Model
        {
            get => this.model;
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                this.model = value;
            }
        }

        public virtual int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 50 || value > 100)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public string Name
        {
            get => this.model;
        }

        public Motorcycle(string model, int horsePower, double cubicCentimeter)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeter;
        }

        public double CalculateRacePoints(int laps)
        {
            double result = this.CubicCentimeters / this.HorsePower * laps;

            return result;
        }
    }
}
