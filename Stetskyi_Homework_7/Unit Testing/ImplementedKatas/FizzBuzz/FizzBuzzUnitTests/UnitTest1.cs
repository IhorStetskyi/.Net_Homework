using NUnit.Framework;
using FizzBuzz;
using System.Collections;
using System;


namespace FizzBuzzUnitTests
{
    public class UnitTest1
    {


        #region Tests
        [TestCaseSource(nameof(ListOfInts), new object[] { 1000 })]
        public void ShouldWriteNumber(int myint, string expectedresult)
        {
            string result = Program.IterateThroughArrayAndDisplayResult(myint);
            Assert.AreEqual(result, expectedresult);
        }


        [TestCaseSource(nameof(ListOfFizz), new object[] { 1000 })]
        public void ShouldWriteFizz(int myint, string expectedresult)
        {
            string result = Program.IterateThroughArrayAndDisplayResult(myint);
            Assert.AreEqual(result, expectedresult);
        }


        [TestCaseSource(nameof(ListOfBuzz), new object[] { 1000 })]
        public void ShouldWriteFizzBuzz(int myint, string expectedresult)
        {
            string result = Program.IterateThroughArrayAndDisplayResult(myint);
            Assert.AreEqual(result, expectedresult);
        }


        [TestCaseSource(nameof(ListOfFizzBuzz), new object[] { 1000 })]
        public void ShouldWriteBuzz(int myint, string expectedresult)
        {
            string result = Program.IterateThroughArrayAndDisplayResult(myint);
            Assert.AreEqual(result, expectedresult);
        }

        [TestCaseSource(nameof(ListOfNegativeNumbers), new object[] { -1000 })]
        public void ShouldWriteException(int myint, string expectedException)
        {
            Exception ex = Assert.Throws<Exception>(() => Program.IterateThroughArrayAndDisplayResult(myint));
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }

        [TestCase(0, "Zero is not allowed")]
        public void ShouldWriteNotInitiatedOrZero(int myint, string expectedException)
        {
            Exception ex = Assert.Throws<Exception>(() => Program.IterateThroughArrayAndDisplayResult(myint));
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }
        #endregion




        /*
         I think this is not a really good example for mocking input data
         ex. [TestCase(3,"Fizz")] would be more reliable, however, this is just study example
         so i tried to do it in more interesting way
        */
        #region Mock Source Data
        public static IEnumerable ListOfInts(int maxValue)
        {
            for (int i = 1; i <= maxValue; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    yield return new object[] { i, i.ToString() };
                }
            }
        }
        public static IEnumerable ListOfFizz(int maxValue)
        {
            for (int i = 1; i <= maxValue; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    yield return new object[] { i, "Fizz" };
                }
            }
        }
        public static IEnumerable ListOfBuzz(int maxValue)
        {
            for (int i = 1; i <= maxValue; i++)
            {
                if (i % 5 == 0 && i % 3 != 0)
                {
                    yield return new object[] { i, "Buzz" };
                }
            }
        }
        public static IEnumerable ListOfFizzBuzz(int maxValue)
        {
            for (int i = 1; i <= maxValue; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    yield return new object[] { i, "FizzBuzz" };
                }
            }
        }
        public static IEnumerable ListOfNegativeNumbers(int maxValue)
        {
            for (int i = -1; i >= maxValue; i--)
            {
                yield return new object[] { i, "Negative number" };
            }
        }
        #endregion
    }
}