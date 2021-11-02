using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal  money;

        private List<Product> bagOfProducts = null;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<Product>();
            
        }

        public string Name { get => name;

            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                } else
                {
                    this.name = value;
                }
            }
        }
        public decimal Money { get => money; 
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                } else
                {
                    this.money = value;
                }
            }
        }
        public string BuyProduct(Product p)
        {
            if (p.Cost <= Money)
            {
                bagOfProducts.Add(p);
                Money -= p.Cost;
                return $"{Name} bought {p.Name}";
                
            }
            else
            {
                return $"{Name} can't afford {p.Name}";
            }
            
        }
        public List<String> GetProducts()
        {
            List<String> list = new List<string>();

            foreach (var prd in bagOfProducts)
            {
                list.Add(prd.Name);
            }
            return list;
        }
        public bool hasProducts()
        {

            if (bagOfProducts.Count>0)
            {
                return true;
            }

            return false;
        }
    }
}
