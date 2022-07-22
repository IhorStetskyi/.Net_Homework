using System;
using Sources;

namespace ImplementingIserializable
{
    class Program
    {
        private const string BinaryPath = @"../../../../FolderToSaveFile/Binary.txt";
        private const string XmlPath = @"../../../../FolderToSaveFile/XML.txt";
        private const string NewtonsoftJsonPath = @"../../../../FolderToSaveFile/JSON.txt";
        private const string CustomPath = @"../../../../FolderToSaveFile/Custom.txt";
        private const string JsonPath = @"../../../../FolderToSaveFile/JSON_Bad.txt";
        static void Main(string[] args)
        {
            DataSerializer dataSerializer = new DataSerializer();

            SimpleClass simpleClass = new SimpleClass();
            simpleClass.MyProperty1 = 123;
            simpleClass.MyProperty2 = "Some Property Value";

            dataSerializer.BinarySerialize(simpleClass, BinaryPath);
            dataSerializer.XMLSerialize(simpleClass, XmlPath);
            dataSerializer.JSONSerializeNewtonsoft(simpleClass, NewtonsoftJsonPath);
            dataSerializer.CustomSerialize(simpleClass, CustomPath);
            dataSerializer.JSONSerialize(simpleClass, JsonPath);

            SimpleClass simpleClass1 = dataSerializer.BinaryDeserialize<SimpleClass>(BinaryPath);
            SimpleClass simpleClass2 = dataSerializer.XMLDeserialize<SimpleClass>(XmlPath);
            SimpleClass simpleClass3 = dataSerializer.JSONDeserializeNewtonsoft<SimpleClass>(NewtonsoftJsonPath);
            SimpleClass simpleClass4 = dataSerializer.JSONDeserialize<SimpleClass>(JsonPath);
            SimpleClass simpleClass5 = dataSerializer.CustomDeserialize<SimpleClass>(CustomPath);
            

            Console.WriteLine($"Simple Class Binary: \nProperty1: {simpleClass1.MyProperty1} \nProperty2: {simpleClass1.MyProperty2}, \nWas deserialised: {simpleClass1.Deserialized} \n=====");
            Console.WriteLine($"Simple Class XML: \nProperty1: {simpleClass2.MyProperty1} \nProperty2: {simpleClass2.MyProperty2}, \nWas deserialised: {simpleClass2.Deserialized} \n=====");
            Console.WriteLine($"Simple Class JSON(Newtonsoft): \nProperty1: {simpleClass3.MyProperty1} \nProperty2: {simpleClass3.MyProperty2}, \nWas deserialised: {simpleClass3.Deserialized} \n=====");
            Console.WriteLine($"Simple Class Json: \nProperty1: {simpleClass4.MyProperty1} \nProperty2: {simpleClass4.MyProperty2}, \nWas deserialised: {simpleClass4.Deserialized} \n=====");
            Console.WriteLine($"Simple Class Custom: \nProperty1: {simpleClass5.MyProperty1} \nProperty2: {simpleClass5.MyProperty2}, \nWas deserialised: {simpleClass5.Deserialized} \n=====");
            
        }
    }
}
