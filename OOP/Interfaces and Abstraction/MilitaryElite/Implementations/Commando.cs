using _7MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7MilitaryElite.Implementations
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lasteName, decimal salary, Corps corps) : base(id, firstName, lasteName, salary, corps)
        {
            Missions = new List<IMission>();
        }

        public List<IMission> Missions { get;set; }

        public void CompleteMission(string codename)
        {
            var mission = this.Missions.FirstOrDefault(x=> x.CodeName==codename);

            mission.Status = Status.Finished;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.ToString());

            str.AppendLine($"Corps: {Corps}");
            str.AppendLine($"Missions:");

            foreach (var item in Missions)
            {
                str.AppendLine($"  {item}");
            }

            return str.ToString().TrimEnd();
        }
    }
}
