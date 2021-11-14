using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Implementations
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lasteName, decimal salary) : base(id, firstName, lasteName, salary)
        {
            Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get;set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine( base.ToString());

            str.AppendLine("Privates:");

            foreach (var @private in Privates)
            {
                str.AppendLine($"  {@private}");
            }

            return str.ToString().TrimEnd();
        }
    }
}
