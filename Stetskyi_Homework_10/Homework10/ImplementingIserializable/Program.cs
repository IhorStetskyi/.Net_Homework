using System;
using Sources;

namespace ImplementingIserializable
{
    class Program
    {
        private const string binaryPath = @"../../../../FolderToSaveFile/Binary.txt";
        private const string xmlPath = @"../../../../FolderToSaveFile/XML.txt";
        private const string newtonsoftJsonPath = @"../../../../FolderToSaveFile/JSON.txt";
        private const string customPath = @"../../../../FolderToSaveFile/Custom.txt";
        private const string jsonPath = @"../../../../FolderToSaveFile/JSON_Bad.txt";
        static void Main(string[] args)
        {
            DataSerializer dataSerializer = new DataSerializer();

            SimpleClass simpleClass = new SimpleClass();
            simpleClass.myProperty1 = 123;
            simpleClass.myProperty2 = "Some Property Value";

            dataSerializer.BinarySerialize(simpleClass, binaryPath);
            dataSerializer.XMLSerialize(simpleClass, xmlPath);
            dataSerializer.JSONSerializeNewtonsoft(simpleClass, newtonsoftJsonPath);
            dataSerializer.CustomSerialize(simpleClass, customPath);
            dataSerializer.JSONSerialize(simpleClass, jsonPath);

            SimpleClass simpleClass1 = dataSerializer.BinaryDeserialize<SimpleClass>(binaryPath);
            SimpleClass simpleClass2 = dataSerializer.XMLDeserialize<SimpleClass>(xmlPath);
            SimpleClass simpleClass3 = dataSerializer.JSONDeserializeNewtonsoft<SimpleClass>(newtonsoftJsonPath);
            SimpleClass simpleClass4 = dataSerializer.JSONDeserialize<SimpleClass>(jsonPath);
            SimpleClass simpleClass5 = dataSerializer.CustomDeserialize<SimpleClass>(customPath);
            

            Console.WriteLine($"Simple Class Binary: \nProperty1: {simpleClass1.myProperty1} \nProperty2: {simpleClass1.myProperty2}, \nWas deserialised: {simpleClass1.deserialized} \n=====");
            Console.WriteLine($"Simple Class XML: \nProperty1: {simpleClass2.myProperty1} \nProperty2: {simpleClass2.myProperty2}, \nWas deserialised: {simpleClass2.deserialized} \n=====");
            Console.WriteLine($"Simple Class JSON(Newtonsoft): \nProperty1: {simpleClass3.myProperty1} \nProperty2: {simpleClass3.myProperty2}, \nWas deserialised: {simpleClass3.deserialized} \n=====");
            Console.WriteLine($"Simple Class Json: \nProperty1: {simpleClass4.myProperty1} \nProperty2: {simpleClass4.myProperty2}, \nWas deserialised: {simpleClass4.deserialized} \n=====");
            Console.WriteLine($"Simple Class Custom: \nProperty1: {simpleClass5.myProperty1} \nProperty2: {simpleClass5.myProperty2}, \nWas deserialised: {simpleClass5.deserialized} \n=====");
            
        }
    }
}
