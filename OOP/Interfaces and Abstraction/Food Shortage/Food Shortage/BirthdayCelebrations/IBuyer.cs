using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    
    public  interface IBuyer
    {
        public int Food { get; set; }
        void BuyFood();
    }
}
