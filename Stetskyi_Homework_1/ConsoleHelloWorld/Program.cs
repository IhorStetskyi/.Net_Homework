using System;
using ConcatenationLib;

namespace ConsoleHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name");
            string Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(ConcatClass.Concat(Name));
        }
    }
}
