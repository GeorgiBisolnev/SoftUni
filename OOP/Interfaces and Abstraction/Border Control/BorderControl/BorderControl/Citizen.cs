using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IPerson , IId 
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            this.id = id;
        }

        public string Name { get;set; }
        public int Age { get; set; }
        public string id { get; set; }

    }
}
