using System;
using Sources;

namespace ImplementingIserializable
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path1 = @"../../../../FolderToSaveFile/Binary.txt";
            string Path2 = @"../../../../FolderToSaveFile/XML.txt";
            string Path3 = @"../../../../FolderToSaveFile/JSON.txt";
            string Path4 = @"../../../../FolderToSaveFile/Custom.txt";
            DataSerializer DS = new DataSerializer();

            SimpleClass simpleClass = new SimpleClass();
            simpleClass.MyProperty1 = 123;
            simpleClass.MyProperty2 = "Some Property Value";

            DS.BinarySerialize(simpleClass, Path1);
            DS.XMLSerialize(simpleClass, Path2);
            DS.JSONSerializeNewtonsoft(simpleClass, Path3);
            DS.CustomSerialize(simpleClass, Path4);

            SimpleClass simpleClass1 = DS.BinaryDeserialize<SimpleClass>(Path1);
            SimpleClass simpleClass2 = DS.XMLDeserialize<SimpleClass>(Path2);
            SimpleClass simpleClass3 = DS.JSONDeserializeNewtonsoft<SimpleClass>(Path3);
            SimpleClass simpleClass4 = DS.CustomDeserialize<SimpleClass>(Path4);

            Console.WriteLine($"Simple Class Binary: \nProperty1: {simpleClass1.MyProperty1} \nProperty2: {simpleClass1.MyProperty2}, \nWas deserialised: {simpleClass1.deserialized} \n=====");
            Console.WriteLine($"Simple Class XML: \nProperty1: {simpleClass2.MyProperty1} \nProperty2: {simpleClass2.MyProperty2}, \nWas deserialised: {simpleClass2.deserialized} \n=====");
            Console.WriteLine($"Simple Class JSON: \nProperty1: {simpleClass3.MyProperty1} \nProperty2: {simpleClass3.MyProperty2}, \nWas deserialised: {simpleClass3.deserialized} \n=====");
            Console.WriteLine($"Simple Class Custom: \nProperty1: {simpleClass4.MyProperty1} \nProperty2: {simpleClass4.MyProperty2}, \nWas deserialised: {simpleClass4.deserialized} \n=====");



        }
    }
}
