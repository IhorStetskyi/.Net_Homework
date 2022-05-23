using NUnit.Framework;
using System;
using DictionaryReplacer;

namespace DictionaryReplacerUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("$tEmP$ here comes the name $nAmE$")]
        public void UltimateTest(string stringToChange)
        {
            Assert.AreEqual("temporary here comes the name John Doe", stringToChange.ReplaceWords());
        }

        [TestCase("some $Inexisting$ word", "No Value Found")]
        public void NoValueFoundException(string stringToChange, string expectedException)
        {
            Exception ex = Assert.Throws<Exception>(() => stringToChange.ReplaceWords());
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }

        [TestCase("wrong", "correct")]
        [TestCase("value1", "value2")]
        [TestCase("temp", "temporary")]
        [TestCase("name", "John Doe")]
        public void CheckGetDictionaryValueMethod(string key, string value)
        {
            string res = ExtensionClass.GetDictionaryValue(key);
            Assert.AreEqual(value, res);
        }

        [TestCase("!SOmeText$", "sometext")]
        [TestCase("$AAAk", "aaa")]
        [TestCase("123456", "2345")]
        [TestCase(" 123 ", "123")]
        public void CheckRemoveFirstAndLastCharacterAndToLowerMethod(string toChange, string expectedResult)
        {
            Assert.AreEqual(expectedResult, toChange.RemoveFirstAndLastCharacterAndToLower());
        }


        [TestCase(new String[] { "just", "to", "test" }, "just to test")]
        [TestCase(new String[] { "       just", "to", "test2      " }, "just to test2")]
        public void CheckFormStringFromArrayMethod(string[] arr, string expectedString)
        {
            Assert.AreEqual(expectedString, arr.FormStringFromArray());
        }

        [TestCase(new String[] { "Some", "$wrong$", "word" }, new String[] { "Some", "correct", "word" })]
        [TestCase(new String[] { "Some", "$WRONG$", "word" }, new String[] { "Some", "correct", "word" })]
        [TestCase(new String[] { "Some", "$WrOnG$", "word" }, new String[] { "Some", "correct", "word" })]
        public void CheckReplaceWordsInArrayMethod(string[] arr, string[] expectedResult)
        {
            Assert.AreEqual(expectedResult, arr.ReplaceWordsInArray());
        }
    }
}