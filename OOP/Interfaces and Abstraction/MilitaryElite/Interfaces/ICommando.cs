using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }

        void CompleteMission(string codename);
    }
}
