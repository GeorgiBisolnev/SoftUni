using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name { get => name; 
            
        private set  {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                } 
             }
        }
        public decimal Cost { get => cost;
            private set 
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.cost = value;
                }
            }
            
        }
    }
}
