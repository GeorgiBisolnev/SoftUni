using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{

    public class Animal
    {
        private string name;
        private string gender;
        private int age;
        public string Name { get=>name; set 
                {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Invalid input!");
                }
                
                name = value;
            }
        }
        public int  Age { get=>age; set {
                if (value<0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            } }
        public String Gender { get=>gender; set {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Invalid input!"); ;
                }
                gender = value;
            } }

        public Animal(string name, int age, String gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return "n/a";
        }
    }
}
