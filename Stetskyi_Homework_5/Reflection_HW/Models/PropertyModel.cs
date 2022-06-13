using System;
using System.Collections.Generic;


namespace Reflection_HW.Models
{
    class PropertyModel
    {
        public string propertyName;

        public IEnumerable<Attribute> attributelist;

        public PropertyModel(string name, IEnumerable<Attribute> atr)
        {
            propertyName = name;
            attributelist = atr;
        }
    }
}
