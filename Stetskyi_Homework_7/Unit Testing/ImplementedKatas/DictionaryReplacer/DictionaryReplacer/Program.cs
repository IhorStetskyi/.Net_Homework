using System;

namespace DictionaryReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please write some text and highlite words with $ sign");
                Console.WriteLine("ex: $temp$ here comes the name $name$  ==>  " + "$temp$ here comes the name $name$".ReplaceWords());
                Console.WriteLine("\n");


                string str = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Changed phrase is: \n" + str.ReplaceWords());

                Console.WriteLine(new string('-', 80));
                Console.WriteLine("\n");

            }
        }
    }
}
