using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    internal class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override string Eat(Food f)
        {
            if (f.GetType().Name == "Meat")
            {
                Weight += f.Quantity*0.25;
                FoodEaten += f.Quantity;
                return ProduceSound();
            }
            else
            {
                return ProduceSound() + "\n" + $"Owl does not eat {f.GetType().Name}!";
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
