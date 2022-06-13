using Reflection_HW.Controllers;
using Reflection_HW.Enums;
using Reflection_HW.TestClasses;
using System;
using Microsoft.Extensions.Configuration;


namespace Reflection_HW
{
    class Program
    {
        public IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            //Comment/Uncomment nesessary void to see AppSettings or Json controller in action

           // AppSettingsConfigControllerExample();

            JsonControllerExample();

        }

        static void AppSettingsConfigControllerExample()
        {
            TestPropertyClass1 tc1 = new TestPropertyClass1();
            TestPropertyClass2 tc2 = new TestPropertyClass2();

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

            TestPropertyClass1 tc1 = new TestPropertyClass1();
            TestPropertyClass2 tc2 = new TestPropertyClass2();

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
