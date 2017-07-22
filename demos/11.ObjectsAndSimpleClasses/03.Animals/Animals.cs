using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Animals
{
    class Dog
    {
        public int Age { get; set; }
        public int LegsCount { get; set; }
        public string Name { get; set; }

        public Dog(string name, int age, int legsCount)
        {
            this.Name = name;
            this.Age = age;
            this.LegsCount = legsCount;
        }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
        }
    }

    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IQ { get; set; }

        public Cat(string name, int age, int iq)
        {
            this.Name = name;
            this.Age = age;
            this.IQ = iq;
        }

        public void ProduceSound()
        {
            Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
        }
    }

    class Snake
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Cruelty { get; set; }

        public Snake(string name, int age, int cruelty)
        {
            this.Name = name;
            this.Age = age;
            this.Cruelty = cruelty;
        }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
        }
    }

    class Animals
    {
        static void Main()
        {
            var dogs = new Dictionary<string, Dog>();
            var cats = new Dictionary<string, Cat>();
            var snakes = new Dictionary<string, Snake>();

            string input = Console.ReadLine();
            while (input != "I'm your Huckleberry")
            {
                string[] inputTokens = input.Split(' ');
                string type = inputTokens[0];

                if (type == "talk")
                {
                    string name = inputTokens[1];

                    if (dogs.ContainsKey(name))
                    {
                        dogs[name].ProduceSound();
                    }
                    else if (cats.ContainsKey(name))
                    {
                        cats[name].ProduceSound();
                    }
                    else
                    {
                        snakes[name].ProduceSound();
                    }
                }
                else
                {
                    string name = inputTokens[1];
                    int age = int.Parse(inputTokens[2]);
                    int param = int.Parse(inputTokens[3]);

                    if (type == "Dog")
                    {
                        dogs.Add(name, new Dog(name, age, param));
                    }
                    else if (type == "Cat")
                    {
                        cats.Add(name, new Cat(name, age, param));
                    }
                    else
                    {
                        snakes.Add(name, new Snake(name, age, param));
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var dogData in dogs)
            {
                Dog dog = dogData.Value;
                Console.WriteLine("Dog: {0}, Age: {1}, Number Of Legs: {2}",
                    dog.Name, dog.Age, dog.LegsCount);
            }

            foreach (var catData in cats)
            {
                Cat cat = catData.Value;
                Console.WriteLine("Cat: {0}, Age: {1}, IQ: {2}",
                    cat.Name, cat.Age, cat.IQ);
            }

            foreach (var snakeData in snakes)
            {
                Snake snake = snakeData.Value;
                Console.WriteLine("Snake: {0}, Age: {1}, Cruelty: {2}",
                    snake.Name, snake.Age, snake.Cruelty);
            }
        }
    }
}
