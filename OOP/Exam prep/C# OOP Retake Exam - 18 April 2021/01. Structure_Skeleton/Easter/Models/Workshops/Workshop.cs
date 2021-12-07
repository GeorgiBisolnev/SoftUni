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
            if (bunny.Energy>0 && hasDye)
            {
                while (!egg.IsDone())
                {
                    hasDye = bunny.Dyes.Any(x => x.IsFinished() != true);
                    if (!hasDye)
                    {
                        break;
                    }

                    egg.GetColored();
                    bunny.Work();

                    foreach (var dye in bunny.Dyes)
                    {
                        if (!dye.IsFinished())
                        {
                            dye.Use();
                        }
                    }
                }
            }
        }
    }
}
