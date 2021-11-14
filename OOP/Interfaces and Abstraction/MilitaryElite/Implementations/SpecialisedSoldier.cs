using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Implementations
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lasteName, decimal salary, Corps corps) : base(id, firstName, lasteName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get;set; }
    }
}
