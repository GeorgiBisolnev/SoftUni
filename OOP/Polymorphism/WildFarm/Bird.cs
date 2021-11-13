using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

    }
}
