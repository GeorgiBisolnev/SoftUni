using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string s)
        {
            
            Console.WriteLine($"Browsing: {s}!");
        }

        public void Call(string s)
        {
            Console.WriteLine("Calling... " + s);
        }
    }
}
