using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCal
{
    class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;            
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    type = value;
                }
                else
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value>=1 && value <=50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                
            }
        }

        

        public double CaloriesPerGram()
        {
            double cal = 0;
            if (Type.ToLower() == "meat")
            {
                cal= 1.2;
            }
            else if (Type.ToLower() == "veggies")
            {
                cal= 0.8;
            }
            else if (Type.ToLower() == "cheese")
            {
                cal = 1.1;
            }
            else if (Type.ToLower() == "sauce")
            {
                cal = 0.9;
            }// else
            //{
            //    cal = 2.0;
            //}

            return cal * Weight*2;
        }

    }
}
