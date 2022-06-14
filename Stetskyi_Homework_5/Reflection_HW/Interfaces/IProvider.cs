using System.Collections.Generic;


namespace Reflection_HW.Interfaces
{
    interface IProvider
    {
        public Dictionary<string, string> GetAllAppSettings();
        public void AddUpdateAppSetting(string key, string value);
        public void RemoveAllAppSettings();
        public string GetSpecificAppSetting(string key);
        public void RemoveSpecificAppSettings(string key);
    }
}
