using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Implementations
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lasteName, int codenumber) : base(id, firstName, lasteName)
        {
            CodeNumber = codenumber;
        }

        public int CodeNumber { get;set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LasteName} Id: {Id}");
            sb.AppendLine($"Code Number: { CodeNumber } ");

            return sb.ToString().TrimEnd();
        }
    }
}
