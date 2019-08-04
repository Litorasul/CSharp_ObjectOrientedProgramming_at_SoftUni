using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CC = 450;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CC)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value < 70)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                base.HorsePower = value;
            }
        }
    }
}
