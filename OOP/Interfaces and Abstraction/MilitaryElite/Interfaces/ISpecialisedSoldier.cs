using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; set; }
    }
}
