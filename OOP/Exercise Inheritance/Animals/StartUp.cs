using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Animals asd = new Kitten("Asd", 13);
            //asd.ProduceSound();
            List<Animal> animals = new List<Animal>();
            string input = System.Console.ReadLine();
            string gender = "n/a";
                int age = 0;
            string name = "n/a";
            string[] info = null;
            while (input != "Beast!")
            {
                switch (input)
                {
                    case "Dog":
                        info = System.Console.ReadLine().Split();
                        name = info[0];
                        age = int.Parse(info[1]);
                        gender = info[2];
                        animals.Add(new Dog(name, age, gender));
                        break;
                    case "Cat":
                        info = System.Console.ReadLine().Split();
                        name = info[0];
                        age = int.Parse(info[1]);
                        gender = info[2];
                        animals.Add(new Cat(name, age, gender));
                        break;
                    case "Frog":
                        info = System.Console.ReadLine().Split();
                        name = info[0];
                        age = int.Parse(info[1]);
                        gender = info[2];
                        animals.Add(new Frog(name, age, gender));
                        break;
                    case "Kitten":
                        info = System.Console.ReadLine().Split();
                        name = info[0];
                        age = int.Parse(info[1]);
                        //gender = info[2];
                        animals.Add(new Kitten(name, age));
                        break;
                    case "Tomcat":
                        info = System.Console.ReadLine().Split();
                        name = info[0];
                        age = int.Parse(info[1]);
                        //gender = info[2];
                        animals.Add(new Tomcat(name, age));
                        break;
                    default:
                        break;
                }
                input = System.Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                System.Console.WriteLine(animal.GetType().Name);
                System.Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                System.Console.WriteLine(animal.ProduceSound()); 
            }
        }
    }
}
