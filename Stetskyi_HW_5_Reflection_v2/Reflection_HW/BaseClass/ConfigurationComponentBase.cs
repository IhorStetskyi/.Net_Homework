using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Reflection_HW.Attributes;
using Reflection_HW.Enums;
using Reflection_HW.Models;
using System.Diagnostics;
using System.Configuration;
using System.ComponentModel;

namespace Reflection_HW.BaseClass
{
    public class ConfigurationComponentBase
    {
        private const string jsonPath = @"../../../appsettings.json";
        JObject Obj;
        JToken JT;
        public List<PropertyModel> propertiesList;

        public ConfigurationComponentBase()
        {
            Refresh();
            propertiesList = new List<PropertyModel>();
            FillPropertiesList();
        }
        public void SaveSettings(object val)
        {
            StackTrace stackTrace = new StackTrace();
            string name = stackTrace.GetFrame(1).GetMethod().Name.Substring(4);
            PropertyModel currentProperty = DefineProperty(name);

            switch (currentProperty.provider)
            {
                case ProviderType.JsonFile:
                    SaveJsonValue(currentProperty.attributeKey, val.ToString());
                    break;
                case ProviderType.AppSettings:
                    SaveAppSettingsValue(currentProperty.attributeKey, val.ToString());
                    break;
            }
            Refresh();
        }
        public T LoadSettings<T>()
        {
            StackTrace stackTrace = new StackTrace();
            string name = stackTrace.GetFrame(1).GetMethod().Name.Substring(4);
            PropertyModel currentProperty = DefineProperty(name);
            var converter = TypeDescriptor.GetConverter(typeof(T));

            switch (currentProperty.provider)
            {
                case ProviderType.JsonFile:
                    string jsonValue = LoadJsonValue(currentProperty.attributeKey);
                    if (jsonValue == "There is no such Value")
                    {
                        Console.WriteLine($"No value found for Property: {currentProperty.propertyName} and Key: {currentProperty.attributeKey}");
                        return default(T);
                    }
                    T resJson = (T)converter.ConvertFrom(jsonValue);
                    return resJson;
                case ProviderType.AppSettings:
                    string appValue = LoadAppSettingsValue(currentProperty.attributeKey);
                    if (appValue == "There is no such Value")
                    {
                        Console.WriteLine($"No value found for Property: {currentProperty.propertyName} and Key: {currentProperty.attributeKey}");
                        return default(T);
                    }
                    T resApp = (T)converter.ConvertFrom(appValue);
                    return resApp;
                default:
                    return (T)Convert.ChangeType("Should never return this", typeof(T));
            }
            
        }
        private void FillPropertiesList()
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ConfigurationItemAttribute atr = (ConfigurationItemAttribute)property.GetCustomAttribute(typeof(ConfigurationItemAttribute));
                if (atr != null)
                {
                    propertiesList.Add(new PropertyModel(property.Name, atr.SettingName, atr.Provider));
                }
            }
        }
        private PropertyModel DefineProperty(string propertyName)
        {
            PropertyModel pm = propertiesList.FirstOrDefault(p => p.propertyName == propertyName);
            return pm;
        }
        private void Refresh()
        {
            Obj = JObject.Parse(File.ReadAllText(jsonPath));
            JT = JToken.Parse(File.ReadAllText(jsonPath));
        }

        #region Json Methods
        private string LoadJsonValue(string key)
        {
            Refresh();
            return JT.Value<string>(key) ?? "There is no such Value";
        }
        private void SaveJsonValue(string key, string value)
        {
            if (LoadJsonValue(key) == "There is no such Value")
            {

                Obj.Add(new JProperty(key, value));
                File.WriteAllText(jsonPath, Obj.ToString());
            }
            else
            {
                Obj[key] = value;
                File.WriteAllText(jsonPath, Obj.ToString());
            }

        }
        public static void ClearAllJsonSettings()
        {
            JObject Obj = new JObject();
            File.WriteAllText(jsonPath, Obj.ToString());
        }
        #endregion

        #region AppSettings Methods
        private string LoadAppSettingsValue(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "There is no such Value";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return "";
            }
        }
        private void SaveAppSettingsValue(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        public static void ClearAllAppSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configFile.AppSettings.Settings.Clear();
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
        #endregion
    }
}
