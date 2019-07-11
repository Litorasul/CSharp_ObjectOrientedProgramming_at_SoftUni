using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public double Lenght
        {
            get { return this.lenght; }
            private set
            {
                ValidateInput(value, "Lenght");
                this.lenght = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                ValidateInput(value, "Width");
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                ValidateInput(value, "Height");
                this.height = value;
            }
        }

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Height = height;
            this.Width = width;
        }

        public double Volume()
        {
            double result = this.Lenght * this.Height * this.Width;
            return result;
        }
        public double SurfaceArea()
        {
            double sideA = this.Lenght * this.Width;
            double sideB = this.Lenght * this.Height;
            double sideC = this.Width * this.Height;
            double result = 2 * sideA + 2 * sideB + 2 * sideC;
            return result;
        }
        public double LateralSurfaceArea()
        {
            double sideA = this.Lenght * this.Height;
            double sideB = this.Width * this.Height;
            double result = 2 * sideA + 2 * sideB;
            return result;
        }

        private void ValidateInput(double value, string type)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }
        }
    }
}
