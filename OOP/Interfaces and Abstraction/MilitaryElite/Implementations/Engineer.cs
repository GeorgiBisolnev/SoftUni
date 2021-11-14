using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Implementations
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lasteName, decimal salary, Corps corps) : base(id, firstName, lasteName, salary, corps)
        {
            Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get;set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.ToString());

            str.AppendLine($"Corps: {Corps}");
            str.AppendLine($"Repairs:");

            foreach (var item in Repairs)
            {
                str.AppendLine($"  {item}");
            }

            return str.ToString().TrimEnd();
        }
    }

    
}
