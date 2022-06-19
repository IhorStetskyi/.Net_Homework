using System;
using Reflection_HW.BaseClass;
using Reflection_HW_Using_DLL.TestClasses;

namespace Reflection_HW_Using_DLL
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationComponentBase.ClearAllAppSettings();
            ConfigurationComponentBase.ClearAllJsonSettings();

            TestClass1 tc1 =new TestClass1();
            TestClass2 tc2 = new TestClass2();

            GetValuesForClass1(tc1);
            GetValuesForClass2(tc2);

            SetValuesForClass1(tc1);
            GetValuesForClass1(tc1);

            SetValuesForClass2(tc2);
            GetValuesForClass1(tc1);
            GetValuesForClass2(tc2);
        }

        private static void GetValuesForClass1(TestClass1 tpc1)
        {
            Console.WriteLine("Getting Json and AppSettings Values for TestPropertyClass1:");
            Console.WriteLine($"TestPropertyClass1 | MyProperty1 from Json | {tpc1.MyProperty1}");
            Console.WriteLine($"TestPropertyClass1 | MyProperty2 from Json | {tpc1.MyProperty2}");
            Console.WriteLine($"TestPropertyClass1 | MyProperty3 from AppSettings | {tpc1.MyProperty3}");
            Console.WriteLine($"TestPropertyClass1 | MyProperty4 from AppSettings | {tpc1.MyProperty4}");
            Console.WriteLine($"TestPropertyClass1 | MyProperty5 from AppSettings | {tpc1.MyProperty5}");
            Console.WriteLine(new string('-', 30));
        }
        private static void GetValuesForClass2(TestClass2 tpc2)
        {
            Console.WriteLine("Getting Json and AppSettings Values for TestPropertyClass2:");
            Console.WriteLine($"TestPropertyClass2 | MyProperty1 from Json | {tpc2.MyProperty1}");
            Console.WriteLine($"TestPropertyClass2 | MyProperty2 from Json | {tpc2.MyProperty2}");
            Console.WriteLine($"TestPropertyClass2 | MyProperty3 from AppSettings | {tpc2.MyProperty3}");
            Console.WriteLine($"TestPropertyClass2 | MyProperty4 from AppSettings | {tpc2.MyProperty4}");
            Console.WriteLine($"TestPropertyClass2 | MyProperty5 from AppSettings | {tpc2.MyProperty5}");
            Console.WriteLine(new string('-', 30));
        }
        private static void SetValuesForClass1(TestClass1 tpc1)
        {
            Console.WriteLine("Setting new Values For Class 1");
            tpc1.MyProperty1 = "Json Value1 for TestPropertyClass1";
            tpc1.MyProperty2 = 123;
            tpc1.MyProperty3 = 10.5f;
            tpc1.MyProperty4 = new TimeSpan(3, 15, 21);
            tpc1.MyProperty5 = new TimeSpan(3, 15, 21);
            Console.WriteLine(new string('-', 30));
        }
        private static void SetValuesForClass2(TestClass2 tpc2)
        {
            Console.WriteLine("Setting new Values For Class 2");
            tpc2.MyProperty1 = "Json Value1 for TestPropertyClass2";
            tpc2.MyProperty2 = 456;
            tpc2.MyProperty3 = 15.5f;
            tpc2.MyProperty4 = new TimeSpan(2, 14, 18);
            tpc2.MyProperty5 = new TimeSpan(2, 14, 18);
            Console.WriteLine(new string('-', 30));
        }
    }
}
