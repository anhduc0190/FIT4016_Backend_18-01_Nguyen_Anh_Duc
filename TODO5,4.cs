using System;
using System.Text;

namespace Inheritance
{
    public class Animal
    {
        public string Name { get; set; }
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }
    public class Cat : Animal 
    {
        public override void MakeSound() 
            {
                Console.WriteLine("Meow! Meow!");
            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- KIỂM TRA LỚP ANIMAL ---");
            Animal genericAnimal = new Animal();
            genericAnimal.Name = "Động vật lạ";
            genericAnimal.MakeSound(); 

            Console.WriteLine("\n--- KIỂM TRA LỚP DOG (CON) ---");
            Dog myDog = new Dog();
            myDog.Name = "Cậu Vàng"; 
            Console.WriteLine($"Tên chó: {myDog.Name}");
            myDog.MakeSound();

            Console.WriteLine("------------------");

            Cat myCat = new Cat();
            myCat.Name = "Mimi";
            Console.WriteLine($"Tên mèo: {myCat.Name}");
            myCat.MakeSound();

            Console.ReadLine();
        }
    }
}