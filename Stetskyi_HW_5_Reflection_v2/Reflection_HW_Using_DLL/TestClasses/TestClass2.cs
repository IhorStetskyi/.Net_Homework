using Reflection_HW.BaseClass;
using Reflection_HW.Attributes;
using Reflection_HW.Enums;
using System;

namespace Reflection_HW_Using_DLL.TestClasses
{
    class TestClass2 : ConfigurationComponentBase
    {
        [ConfigurationItem("Key1", ProviderType.JsonFile)]
        public string MyProperty1 { get { return LoadSettings<string>(); } set { SaveSettings(value); } }

        [ConfigurationItem("Key2", ProviderType.JsonFile)]
        public int MyProperty2 { get { return LoadSettings<int>(); } set { SaveSettings(value); } }

        [ConfigurationItem("Key3", ProviderType.AppSettings)]
        public float MyProperty3 { get { return LoadSettings<float>(); } set { SaveSettings(value); } }

        [ConfigurationItem("Key4", ProviderType.AppSettings)]
        public TimeSpan MyProperty4 { get { return LoadSettings<TimeSpan>(); } set { SaveSettings(value); } }
        [ConfigurationItem("Key5", ProviderType.JsonFile)]
        public TimeSpan MyProperty5 { get { return LoadSettings<TimeSpan>(); } set { SaveSettings(value); } }
        public string MyProperty6 { get; set; }
    }
}
