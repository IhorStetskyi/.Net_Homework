using System;

namespace FizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(WriteFizzBuzz(i));
            }
        }

        public static string WriteFizzBuzz(int myint)
        {
            ExceptionHandler(myint);


            if (myint % 3 == 0 && myint % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (myint % 3 == 0)
            {
                return "Fizz";
            }
            else if (myint % 5 == 0)
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
