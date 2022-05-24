using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please Write something into console and press \"Enter\"");
                try
                {
                    WriteFirstCharacter(Console.ReadLine());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Looks like tou did not enter any value");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Some else unhandled exception");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void WriteFirstCharacter(string input)
        {
            Console.WriteLine($"First sign in \"{input}\" string is: \n{input.Substring(0, 1)}\n");
        }
    }
}