using Reflection_HW.Attributes;
using Reflection_HW.Enums;
using Reflection_HW.Interfaces;
using Reflection_HW.Models;
using Reflection_HW.Providers;
using System;
using System.Collections.Generic;
using System.Reflection;


namespace Reflection_HW.Controllers
{
    public class ProviderController
    {
        private Dictionary<string, string> settings = new Dictionary<string, string>();
        private List<PropertyModel> propModelList = new List<PropertyModel>();
        private IProvider provider;
        private Type type;

        /// <summary>
        /// ProviderController constructor;
        /// Provider p => AppConfig or JsonFile;
        /// object type => class with ConfigurationItemAttributes;
        /// </summary>
        /// <param name="p">Select provider AppConfig or JsonFile</param>
        /// <param name="type">Select class with ConfigurationItemAttributes</param>
        public ProviderController(ProviderEnum p, object type)
        {
            SetProvider(p);
            this.type = type.GetType();
        }
        public void WriteAllAppSettingsToConsole()
        {
            settings = provider.GetAllAppSettings();
            foreach (KeyValuePair<string, string> kvp in settings)
            {
                Console.WriteLine($"Key: {kvp.Key} || Value: {kvp.Value}");
            }
        }
        private void FillPropertiesList()
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                propModelList.Add(new PropertyModel(prop.Name, prop.GetCustomAttributes(typeof(ConfigurationItemAttribute))));
            }
        }
        public void UpdateSettings()
        {
            FillPropertiesList();
            foreach (PropertyModel prop in propModelList)
            {
                foreach (ConfigurationItemAttribute attr in prop.attributelist)
                {
                    provider.AddUpdateAppSetting(attr.ReturnKey().ToString(), attr.ReturnValue().ToString());
                }
            }
        }
        public void ReplaceSettings()
        {
            provider.RemoveAllAppSettings();
            FillPropertiesList();
            foreach (PropertyModel prop in propModelList)
            {
                foreach (ConfigurationItemAttribute attr in prop.attributelist)
                {
                    provider.AddUpdateAppSetting(attr.ReturnKey().ToString(), attr.ReturnValue().ToString());
                }
            }
        }
        public void RemoveAllSettings()
        {
            provider.RemoveAllAppSettings();
        }

        private void SetProvider(ProviderEnum p)
        {
            switch (p)
            {
                case ProviderEnum.AppSettings:
                    provider = new AppConfigProvider();
                    break;
                case ProviderEnum.JsonFile:
                    provider = new JsonFileProvider();
                    break;
            }
        }
    }
}
