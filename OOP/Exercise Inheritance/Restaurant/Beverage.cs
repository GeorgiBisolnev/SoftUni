using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public double Milliliters { get; set; }
        public Beverage(string name, decimal price, double ml) : base(name, price)
        {
            Milliliters = ml;
        }
    }
}
