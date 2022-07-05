using System;

namespace FizzBuzz
{
    public class Program
    {
        const int multiplyToThree = 3;
        const int multiplyToFive = 5;
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(IterateThroughArrayAndDisplayResult(i));
            }
        }

        public static string IterateThroughArrayAndDisplayResult(int myint)
        {
            ExceptionHandler(myint);


            if (myint % multiplyToThree == 0 && myint % multiplyToFive == 0)
            {
                return "FizzBuzz";
            }
            else if (myint % multiplyToThree == 0)
            {
                return "Fizz";
            }
            else if (myint % multiplyToFive == 0)
            {
                return "Buzz";
            }
            else
            {
                return myint.ToString();
            }
        }

        static void ExceptionHandler(int number)
        {
            if (number < 0)
            {
                throw new Exception("Negative number");
            }
            else if (number == 0)
            {
                throw new Exception("Zero is not allowed");
            }
        }
    }

}
