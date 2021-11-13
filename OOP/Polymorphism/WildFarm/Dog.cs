using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Eat(Food f)
        {
            if (f.GetType().Name == "Meat")
            {
                Weight += f.Quantity*0.4;
                FoodEaten += f.Quantity;
                return ProduceSound();
            }
            else
            {
                return ProduceSound() + "\n" + $"Dog does not eat {f.GetType().Name}!";
            }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
