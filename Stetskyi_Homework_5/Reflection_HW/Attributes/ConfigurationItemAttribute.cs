using System;


namespace Reflection_HW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingKeyString { get; set; }
        public string SettingValueString { get; set; }
        public int SettingKeyInt { get; set; }
        public int SettingValueInt { get; set; }
        public double SettingKeyFloat { get; set; }
        public double SettingValueFloat { get; set; }
        public TimeSpan SettingKeyTimeSpan { get; set; }
        public TimeSpan SettingValueTimeSpan { get; set; }

        public string keyType { get; set; }
        public string valueType { get; set; }

        public ConfigurationItemAttribute(object key, object value)
        {
            keyType = key.GetType().Name;
            valueType = value.GetType().Name;
            FillCorrespondingKey(keyType, key);
            FillCorrespondingValue(valueType, value);

        }

        private void FillCorrespondingKey(string k, object value)
        {
            switch (k)
            {
                case "Int32":
                    SettingKeyInt = (int)value;
                    break;
                case "String":
                    SettingKeyString = (string)value;
                    break;
                case "Double":
                    SettingKeyFloat = (double)value;
                    break;
                case "Single":
                    SettingKeyFloat = (double)value;
                    break;
                case "TimeSpan":
                    SettingKeyTimeSpan = (TimeSpan)value;
                    break;
            }
        }
        private void FillCorrespondingValue(string v, object value)
        {
            switch (v)
            {
                case "Int32":
                    SettingValueInt = (int)value;
                    break;
                case "String":
                    SettingValueString = (string)value;
                    break;
                case "Double":
                    SettingValueFloat = (double)value;
                    break;
                case "Single":
                    SettingValueFloat = (double)value;
                    break;
                case "TimeSpan":
                    SettingValueTimeSpan = (TimeSpan)value;
                    break;
            }
        }

        public object ReturnKey()
        {
            switch (keyType)
            {
                case "Int32":
                    return SettingKeyInt;
                case "String":
                    return SettingKeyString;
                case "Double":
                    return SettingKeyFloat;
                case "Single":
                    return SettingKeyFloat;
                case "TimeSpan":
                    return SettingKeyTimeSpan;
                default:
                    return null;
            }
        }
        public object ReturnValue()
        {
            switch (valueType)
            {
                case "Int32":
                    return SettingValueInt;
                case "String":
                    return SettingValueString;
                case "Double":
                    return SettingValueFloat;
                case "Single":
                    return SettingValueFloat;
                case "TimeSpan":
                    return SettingValueTimeSpan;
                default:
                    return null;
            }
        }
    }
}
