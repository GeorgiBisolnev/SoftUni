using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(string n, int a)
        {
            if (a>=0)
            {
                Name = n;
                Age = a;
            }
            
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"Name: {Name}, Age: {Age}");
            return str.ToString();
        }
    }
}
