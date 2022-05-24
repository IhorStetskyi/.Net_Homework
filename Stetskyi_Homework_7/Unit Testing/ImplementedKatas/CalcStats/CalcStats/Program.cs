using System;

namespace CalcStats
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -1, 4, 0, 25, -7 };
            string arrayline = "";

            foreach (int item in array)
            {
                arrayline += (item.ToString() + " ");
            }

            Result result = new Result(array);
            

            Console.WriteLine($"Stats for the ({arrayline}) values:\n");
            result.ShowResults();
        }
    }
}
