using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string Eat(Food f)
        {
                Weight += f.Quantity * 0.35;
                FoodEaten += f.Quantity;
                return ProduceSound();
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
