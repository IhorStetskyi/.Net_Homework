using Newtonsoft.Json;
using Reflection_HW.Interfaces;
using Reflection_HW.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Reflection_HW.Providers
{
    class JsonFileProvider : IProvider
    {
        SettingModel settingModel;
        string json;


        public void AddUpdateAppSetting(string key, string value)
        {
            Deserialise();
            if (settingModel.settings.ContainsKey(key))
            {
                settingModel.settings[key] = value;
            }
            else
            {
                settingModel.Add(key, value);
            }
            Serialise();
        }

        public Dictionary<string, string> GetAllAppSettings()
        {
            Deserialise();
            return settingModel.settings;
        }

        public string GetSpecificAppSetting(string key)
        {
            Deserialise();
            if (settingModel.settings.ContainsKey(key))
            {
                return settingModel.settings[key];
            }
            else
            {
                Console.WriteLine("No such key");
                return null;
            }
        }

        public void RemoveAllAppSettings()
        {
            settingModel = new SettingModel();
            Serialise();
        }

        public void RemoveSpecificAppSettings(string key)
        {
            Deserialise();
            if (settingModel.settings.ContainsKey(key))
            {
                settingModel.settings.Remove(key);
            }
            else
            {
                Console.WriteLine("No such key to remove");
            }
            Serialise();
        }


        private void Deserialise()
        {
            settingModel = new SettingModel();
            json = File.ReadAllText(@"../../../appsettings.json");
            settingModel = JsonConvert.DeserializeObject<SettingModel>(json);
        }
        private void Serialise()
        {
            var str = JsonConvert.SerializeObject(settingModel, Formatting.Indented);
            File.WriteAllText(@"../../../appsettings.json", str);
        }
    }
}
