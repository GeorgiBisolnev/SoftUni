﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _7MilitaryElite.Interfaces
{
    public interface  ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Privates { get; set; }
    }
}
