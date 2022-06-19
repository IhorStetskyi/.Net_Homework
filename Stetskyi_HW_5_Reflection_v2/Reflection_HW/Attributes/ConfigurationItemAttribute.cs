using Reflection_HW.Enums;
using System;


namespace Reflection_HW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName;
        public ProviderType Provider;
        public ConfigurationItemAttribute(string settingName, ProviderType provider)
        {
            SettingName = settingName;
            Provider = provider;
        }
    }
}
