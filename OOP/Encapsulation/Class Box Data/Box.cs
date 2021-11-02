using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Box
    {

        private double length;
        private double width;
        private double height;


        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;

            private set
            {
                if (value>0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Height { get => height;
                private set {
                if (value > 0)
                {
                    height = value;
                } else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");                
                }
            } 
        }


        //Volume = lwh
        //Lateral Surface Area = 2lh + 2wh
        //Surface Area = 2lw + 2lh + 2wh
        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }
        public double LateralSurfaceArea()
        {
            return this.Length * this.Height * 2 + 2 * this.Width * this.Height;
        }
        public double Volume()
        {
            return Length * Width * Height;
        }
    }
}
