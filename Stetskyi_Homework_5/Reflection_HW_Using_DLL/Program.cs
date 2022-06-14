using System;
using Reflection_HW.Controllers;
using Reflection_HW.Enums;
using Reflection_HW_Using_DLL.TestClasses;

namespace Reflection_HW_Using_DLL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comment/Uncomment nesessary void to see AppSettings or Json controller in action

            AppSettingsConfigControllerExample();

            JsonControllerExample();
        }

        static void AppSettingsConfigControllerExample()
        {
            TestClass1 tc1 = new TestClass1();
            TestClass2 tc2 = new TestClass2();

            ProviderController controller1 = new ProviderController(ProviderEnum.AppSettings, tc1);
            ProviderController controller2 = new ProviderController(ProviderEnum.AppSettings, tc2);

            Console.WriteLine("controller1.WriteAllAppSettingsToConsole();");
            controller1.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller2.WriteAllAppSettingsToConsole();");
            controller2.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller1.UpdateSettings();");
            controller1.UpdateSettings();
            controller1.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller2.UpdateSettings();");
            controller2.UpdateSettings();
            controller2.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller1.ReplaceSettings();");
            controller1.ReplaceSettings();
            controller1.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

        }
        static void JsonControllerExample()
        {

            TestClass1 tc1 = new TestClass1();
            TestClass2 tc2 = new TestClass2();

            ProviderController controller1 = new ProviderController(ProviderEnum.JsonFile, tc1);
            ProviderController controller2 = new ProviderController(ProviderEnum.JsonFile, tc2);

            Console.WriteLine("controller1.WriteAllAppSettingsToConsole();");
            controller1.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller2.WriteAllAppSettingsToConsole();");
            controller2.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller1.UpdateSettings();");
            controller1.UpdateSettings();
            controller1.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller2.UpdateSettings();");
            controller2.UpdateSettings();
            controller2.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");

            Console.WriteLine("controller1.ReplaceSettings();");
            controller1.ReplaceSettings();
            controller1.WriteAllAppSettingsToConsole();
            Console.WriteLine("--------------------------- \n\n");
        }
    }
}
