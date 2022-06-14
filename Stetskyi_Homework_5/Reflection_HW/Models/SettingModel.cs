using System.Collections.Generic;


namespace Reflection_HW.Models
{
    class SettingModel
    {
        public Dictionary<string, string> settings;


        public SettingModel()
        {
            settings = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            settings.Add(key, value);
        }
        public void Clear()
        {
            settings = new Dictionary<string, string>();
        }

    }
}
