using NUnit.Framework;
using CalcStats;

namespace CalcStatsUnitTests
{
    public class Tests
    {
        StatsCalculator statsCalculator;
        [SetUp]
        public void Setup()
        {
            statsCalculator = new StatsCalculator();
        }

        //MaxTests
        [TestCase(1, 2, 3, 4, 5)]
        public void FindMax(params int[] myparams)
        {
            Assert.AreEqual(5, statsCalculator.FindMax(myparams));
        }

        [TestCase(-1, -2, -3, -4, -5)]
        public void FindMaxFromNegative(params int[] myparams)
        {
            Assert.AreEqual(-1, statsCalculator.FindMax(myparams));
        }

        [TestCase(-1, -2, -3, -4, -5, 0, 1, 2, 3, 4, 5, 6, 7)]
        public void FindMaxFromMixed(params int[] myparams)
        {
            Assert.AreEqual(7, statsCalculator.FindMax(myparams));
        }


        //MinTests
        [TestCase(1, 2, 3, 4, 5)]
        public void FindMin(params int[] myparams)
        {
            Assert.AreEqual(1, statsCalculator.FindMin(myparams));
        }

        [TestCase(-1, -2, -3, -4, -5)]
        public void FindMinFromNegative(params int[] myparams)
        {
            Assert.AreEqual(-5, statsCalculator.FindMin(myparams));
        }

        [TestCase(-1, -2, -3, -4, -5, 0, 1, 2, 3, 4, 5, 6, 7)]
        public void FindMinFromMixed(params int[] myparams)
        {
            Assert.AreEqual(-5, statsCalculator.FindMin(myparams));
        }


        //AVGTests
        [TestCase(1, 2, 3, 4, 5)]
        public void FindAvg(params int[] myparams)
        {
            Assert.AreEqual(3, statsCalculator.GetAvg(myparams));
        }

        [TestCase(-1, -2, -3, -4, -5)]
        public void FindAvgFromNegative(params int[] myparams)
        {
            Assert.AreEqual(-3, statsCalculator.GetAvg(myparams));
        }

        [TestCase(-5, -10, 10, 25)]
        public void FindAvgFromMixed(params int[] myparams)
        {
            Assert.AreEqual(5, statsCalculator.GetAvg(myparams));
        }

        //CountTest
        [TestCase(-1, 2, -3, 4, -5, 6, -7, 8, -9, 10)]
        public void FindCountFromMixed(params int[] myparams)
        {
            Assert.AreEqual(10, statsCalculator.GetCount(myparams));
        }

        //BestTest
        [TestCase(-20, 20, 40, 50, 0)]
        public void BestTest(params int[] myparams)
        {
            Result real = new Result(myparams);
            Result expected = new Result(-20, 50, 5, 18);

            Assert.AreEqual(expected.MinValue, real.MinValue);
            Assert.AreEqual(expected.MaxValue, real.MaxValue);
            Assert.AreEqual(expected.Count, real.Count);
            Assert.AreEqual(expected.Avg, real.Avg);
        }

    }
}