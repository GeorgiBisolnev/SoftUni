using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCal
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppingList = null;

        public Pizza(string name, Dough dough )
        {
            Dough = dough;
            Name = name;
            toppingList = new List<Topping>();
        }
        public Pizza()
        {

        }

        public Dough Dough
        {
            get { return dough; }
            private set
            {
                dough = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length>15|| string.IsNullOrEmpty(value))
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                else
                name = value;
            }
        }
        public int NumberOfToppings => toppingList.Count;

        public void AddTopping(Topping t)
        {
            if (NumberOfToppings+1<=10)
            {
                toppingList.Add(t);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            
        }

        public IReadOnlyList<Topping> GetToppings => this.toppingList.AsReadOnly();
        public double TotalCalories()
        {
            double toppingCalories = 0;
            foreach (var toping in toppingList)
            {
                toppingCalories += toping.CaloriesPerGram();
            }
            return Dough.CalculCallories() + toppingCalories;
        }
    }
}
