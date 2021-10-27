using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal defCakePrice = 5;
        private const double defCalories = 1000;
        private const double defGrams = 250;
        public Cake(string name) : base( name, defCakePrice, defGrams, defCalories)
        {

        }
    }
}
