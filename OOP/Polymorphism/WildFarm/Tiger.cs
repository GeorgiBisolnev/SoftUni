using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Eat(Food f)
        {
            if (f.GetType().Name == "Meat")
            {
                Weight += f.Quantity;
                FoodEaten += f.Quantity;
                return ProduceSound();
            }
            else
            {
                return ProduceSound() + "\n" + $"Tiger does not eat {f.GetType().Name}!";
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

    }
}
