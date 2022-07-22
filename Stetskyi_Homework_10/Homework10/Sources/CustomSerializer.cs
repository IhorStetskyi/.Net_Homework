using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Sources
{
    class CustomSerializer : IFormatter
    {
        private Type _type;
        public CustomSerializer(Type type)
        {
            _type = type;
        }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            object obj = Activator.CreateInstance(_type);
            using (var sr = new StreamReader(serializationStream))
            {
                string typeName = sr.ReadLine();
                string contents = sr.ReadToEnd();

                List<string> pairs = contents.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key, value;

                foreach (string pair in pairs)
                {
                    string[] keyValue = pair.Split(':');
                    key = keyValue[0];
                    value = keyValue[1];

                    PropertyInfo intProperty = _type.GetProperty(key, typeof(int));
                    PropertyInfo stringProperty = _type.GetProperty(key, typeof(string));
                    PropertyInfo boolProperty = _type.GetProperty(key, typeof(bool));

                    if (intProperty != null)
                    {
                        intProperty.SetValue(obj, Int32.Parse(value));
                    }
                    else if (stringProperty != null)
                    {
                        stringProperty.SetValue(obj, value);
                    }
                    else if (stringProperty != null)
                    {
                        boolProperty.SetValue(obj, Boolean.Parse(value));
                    }
                }
            }
            return obj;

        }

        public void Serialize(Stream serializationStream, object graph)
        {
            List<PropertyInfo> properties = _type.GetProperties().ToList();
            List<FieldInfo> fields = _type.GetFields().ToList();
            StreamWriter streamWriter = new StreamWriter(serializationStream);
            streamWriter.WriteLine(_type.Name);
            foreach (PropertyInfo propertyInfo in properties)
            {
                streamWriter.WriteLine($"{propertyInfo.Name}:{propertyInfo.GetValue(graph)}");
            }
            foreach (FieldInfo field in fields)
            {
                streamWriter.WriteLine($"{field.Name}:{field.GetValue(graph)}");
            }
            streamWriter.Flush();
        }


    }
}
