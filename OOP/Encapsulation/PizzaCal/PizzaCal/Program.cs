using System;
using System.Collections.Generic;

namespace PizzaCal
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] info = command.Split();
            string pizzaName = "";
            Pizza myPizza = new Pizza();
            Dough d = new Dough();
            try
            {              
                pizzaName = info[1];
                command = Console.ReadLine();
                info = command.Split();
                        string flourType = info[1];
                        string bakingTechnique = info[2];
                        double weight = double.Parse(info[3]);
                        d = new Dough(flourType, bakingTechnique, weight);

                command = Console.ReadLine();
                myPizza = new Pizza(pizzaName, d);
                while (command!="END")
                {

                    info = command.Split();
                            string type = info[1];    
                            weight = double.Parse(info[2]);
                            Topping t = new Topping(type, weight);
                        myPizza.AddTopping(t);
                    command = Console.ReadLine();
                }
                Console.WriteLine($"{myPizza.Name} - {myPizza.TotalCalories():F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
