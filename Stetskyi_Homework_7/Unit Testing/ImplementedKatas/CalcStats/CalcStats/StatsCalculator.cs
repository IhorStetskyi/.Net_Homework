using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcStats
{
    public class StatsCalculator
    {
        public int FindMax(params int[] myparams)
        {
            int res = int.MinValue;
            foreach (int item in myparams)
            {
                if (item > res)
                {
                    res = item;
                }
            }
            return res;
        }
        public int FindMin(params int[] myparams)
        {
            int res = int.MaxValue;
            foreach (int item in myparams)
            {
                if (item < res)
                {
                    res = item;
                }
            }
            return res;
        }
        public decimal GetAvg(params int[] myparams)
        {
            decimal res = 0m;
            foreach (int item in myparams)
            {
                res += item;
            }
            return (res / myparams.Length);
        }
        public int GetCount(params int[] myparams)
        {
            return myparams.Length;
        }
    }
}
