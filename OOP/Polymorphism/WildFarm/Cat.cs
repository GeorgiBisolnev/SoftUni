using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Eat(Food f)
        {

            if (f.GetType().Name == "Vegetable" || f.GetType().Name == "Meat")
            {
                Weight += f.Quantity * 0.30;
                FoodEaten += f.Quantity;
                return ProduceSound();
            }
            else
            {
                
                return ProduceSound() +"\n"+ $"Cat does not eat {f.GetType().Name}!";
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

    }
}
