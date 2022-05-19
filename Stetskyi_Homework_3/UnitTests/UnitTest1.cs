using NUnit.Framework;
using FoldersHW;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {
        FilterValuesList fv;
        List<string> listToBeFiltered;
        List<string> result;
        List<string> ToCompare;

        [SetUp]
        public void Setup()
        {
            fv = new FilterValuesList();
            listToBeFiltered = new List<string>();
            result = new List<string>();
            ToCompare = new List<string>();
            fv.Add("Folder");
            fv.Add("Test");
            fv.Add("Some Value");
            listToBeFiltered.Add("Something");
            listToBeFiltered.Add("This is my folder");
            listToBeFiltered.Add("Correct test");
            listToBeFiltered.Add("Something else");
        }



        [Test]
        public void ReturnInclude()
        {
            ToCompare.Add("This is my folder");
            ToCompare.Add("Correct test");

            result = StaticFilterMethods.ReturnInclude(fv, listToBeFiltered, FolderOrFileEnum.Folder);

            CollectionAssert.AreEqual(result, ToCompare);
        }

        [Test]
        public void ReturnExclude()
        {
            ToCompare.Add("Something");
            ToCompare.Add("Something else");

            result = StaticFilterMethods.ReturnExclude(fv, listToBeFiltered, FolderOrFileEnum.Folder);

            CollectionAssert.AreEqual(result, ToCompare);
        }



    }
}