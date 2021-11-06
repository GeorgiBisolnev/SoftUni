using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class Phone : ICallable
    {
        public void Call(string s)
        {
            Console.WriteLine("Dialing... " + s);
        }
    }
}
