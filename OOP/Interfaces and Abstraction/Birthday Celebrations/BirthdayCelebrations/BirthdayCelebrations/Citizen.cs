using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IPerson , IId , IBirth
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            this.id = id;
            Birthdate = birthdate;
        }

        public string Name { get;set; }
        public int Age { get; set; }
        public string id { get; set; }
        public string Birthdate { get;set; }
    }
}
