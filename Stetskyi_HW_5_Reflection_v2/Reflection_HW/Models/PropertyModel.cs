using Reflection_HW.Enums;

namespace Reflection_HW.Models
{
    public class PropertyModel
    {
        public string propertyName;
        public string attributeKey;
        public ProviderType provider;

        public PropertyModel(string name, string key, ProviderType prov)
        {
            propertyName = name;
            attributeKey = key;
            provider = prov;
        }
    }
}
