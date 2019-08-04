using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CC = 125;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CC)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                base.HorsePower = value;
            }
        }
    }
}
