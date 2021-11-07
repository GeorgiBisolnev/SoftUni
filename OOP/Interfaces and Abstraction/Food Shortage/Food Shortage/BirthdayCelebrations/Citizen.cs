using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IPerson, IId, IBirth, IBuyer
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
        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
