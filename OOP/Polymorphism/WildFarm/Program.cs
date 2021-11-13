using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            while ((command=Console.ReadLine())!="End")
            {
                string[] infoAnimal = command.Split();
                string[] infoVeg = Console.ReadLine().Split();
                Food curFood = null;
                string AnimalType = infoAnimal[0];

                switch (infoVeg[0])
                {
                    case "Vegetable":
                        curFood = new Vegetable(int.Parse(infoVeg[1]));
                        foods.Add(curFood);
                        break;
                    case "Fruit":
                        curFood = new Fruit(int.Parse(infoVeg[1]));
                        foods.Add(curFood);
                        break;
                    case "Meat":
                        curFood = new Meat(int.Parse(infoVeg[1]));
                        foods.Add(curFood);
                        break;
                    case "Seeds":
                        curFood = new Seeds(int.Parse(infoVeg[1]));
                        foods.Add(curFood);
                        break;
                    default:
                        break;
                }

                
                switch (AnimalType)
                {
                    case "Cat":

                        //Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}"
                        animals.Add(new Cat(infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3], infoAnimal[4]));
                        break;
                    case "Tiger":
                        //Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}"
                        animals.Add(new Tiger(infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3], infoAnimal[4]));
                        break;
                    case "Hen":

                        //{Type} {Name} {Weight} {WingSize}
                        animals.Add(new Hen(infoAnimal[1], double.Parse(infoAnimal[2]), double.Parse(infoAnimal[3])));
                        break;
                    case "Owl":
                        //{Type} {Name} {Weight} {WingSize}
                        animals.Add(new Owl(infoAnimal[1], double.Parse(infoAnimal[2]), double.Parse(infoAnimal[3])));
                        break;
                    case "Mouse":
                        //{Type} {Name} {Weight} {LivingRegion}
                        animals.Add(new Mouse(infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3]));
                        break;
                    case "Dog":
                        //{Type} {Name} {Weight} {LivingRegion}
                        animals.Add(new Dog(infoAnimal[1], double.Parse(infoAnimal[2]), infoAnimal[3]));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].Eat(foods[i]));
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
