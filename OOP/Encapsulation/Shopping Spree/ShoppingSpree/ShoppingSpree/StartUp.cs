using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] ppl = Console.ReadLine().Split( ';' , StringSplitOptions.RemoveEmptyEntries);
                

                List<Person> persons = new List<Person>();
                List<Product> products = new List<Product>();
                

                for (int i = 0; i < ppl.Length; i++)
                {
                    
                    string[] personInfo = ppl[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    if (personInfo.Length<2)
                    {
                        Console.WriteLine("Name cannot be empty");
                        return;
                    }
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);
                    persons.Add(new Person(name, money));

                }
                string[] pds = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < pds.Length; i++)
                {
                    string[] productInfo = pds[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    if (productInfo.Length < 2)
                    {
                        Console.WriteLine("Name cannot be empty");
                        return;
                    }
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);
                    products.Add(new Product(name, cost));

                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] info = command.Split();
                    Person currentPerson = persons.FirstOrDefault(p => p.Name == info[0]);
                    Product currentProduct = products.FirstOrDefault(p => p.Name == info[1]);
                    Console.WriteLine(currentPerson.BuyProduct(currentProduct));


                    command = Console.ReadLine();
                }

                foreach (var person in persons)
                {
                    if (person.hasProducts() == false)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.Write($"{person.Name} - ");
                        Console.WriteLine(string.Join(", ", person.GetProducts()));
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
