using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Eat(Food f)
        {
            if (f.GetType().Name== "Vegetable" || f.GetType().Name == "Fruit")
            {
                Weight += f.Quantity * 0.1;
                FoodEaten += f.Quantity;
                return ProduceSound();
            }
            else
            {
                return ProduceSound() + "\n" + $"Mouse does not eat {f.GetType().Name}!";
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
