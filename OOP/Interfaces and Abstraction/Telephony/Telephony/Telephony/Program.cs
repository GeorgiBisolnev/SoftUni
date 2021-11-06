using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();
            var oldPhone = new Phone();

            foreach (var phone in phones)
            {
                bool flag = true;
                for (int i = 0; i < phone.Length; i++)
                {
                    int number = 0;
                    bool success = int.TryParse(phone[i].ToString(), out number);
                    if (!success)
                    {
                        flag = false;
                        break;
                    } 
                }

                if (flag == true && phone.Length == 10)
                {
                    smartphone.Call(phone);
                }
                else if (flag == true && phone.Length == 7)
                {
                    oldPhone.Call(phone);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var url in urls)
            {
                bool flag = true;
                for (int i = 0; i < url.Length; i++)
                {
                    int number = 0;
                    bool success = int.TryParse(url[i].ToString(), out number);
                    if (success)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag == true )
                {
                    smartphone.Browse(url);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
