using System;
using System.Collections.Generic;
using System.Text;
using _7MilitaryElite.Interfaces;

namespace _7MilitaryElite.Implementations
{
    public abstract class Soldier : ISolder
    {
        protected Soldier(int id, string firstName, string lasteName)
        {
            Id = id;
            FirstName = firstName;
            LasteName = lasteName;
        }

        public int Id { get;set; }
        public string FirstName { get; set; }
        public string LasteName { get; set; }
    }
}
