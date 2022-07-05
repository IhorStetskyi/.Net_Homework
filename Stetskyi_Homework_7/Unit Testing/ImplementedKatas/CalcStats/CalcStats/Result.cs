﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcStats
{
    public class Result
    {
        StatsCalculator calculator;

        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public decimal Count { get; set; }
        public decimal Avg { get; set; }


        public Result(int min, int max, int count, decimal avg)
        {
            MinValue = min;
            MaxValue = max;
            Count = count;
            Avg = avg;
        }

        public Result(int[] array)
        {
            calculator = new StatsCalculator();
            MinValue = calculator.FindMin(array);
            MaxValue = calculator.FindMax(array);
            Count = calculator.GetCount(array);
            Avg = calculator.GetAvg(array);
        }
        public void ShowResults()
        {
            Console.WriteLine($"Max value is: {MaxValue}");
            Console.WriteLine($"Min value is: {MinValue}");
            Console.WriteLine($"Avg value is: {Avg}");
            Console.WriteLine($"Count is: {Count}");
            Console.WriteLine(new string('-',50));
        }
    }
}
