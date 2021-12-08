using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Color(IEgg egg, IBunny bunny)
        {
            bool hasDye = bunny.Dyes.Any(x => x.IsFinished() != true);

            while (!egg.IsDone() && hasDye && bunny.Energy>0)
            {

                egg.GetColored();
                bunny.Work();

                foreach (var dye in bunny.Dyes)
                {
                    if (!dye.IsFinished())
                    {
                        dye.Use();
                        break;
                    }
                }

                hasDye = bunny.Dyes.Any(x => x.IsFinished() != true);
            }
            //bunny.Dyes.ToList().RemoveAll(d => d.Power == 0);
        }
    }
}
