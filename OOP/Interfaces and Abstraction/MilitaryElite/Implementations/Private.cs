using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Implementations
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lasteName, decimal salary) : base(id, firstName, lasteName)
        {
            Salary = salary;
        }

        public decimal Salary { get;set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LasteName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}
