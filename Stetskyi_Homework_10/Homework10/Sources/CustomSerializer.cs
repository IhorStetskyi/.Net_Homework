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
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

                    PropertyInfo propertyInfo = _type.GetProperty(key);
                    FieldInfo fieldInfo = _type.GetField(key);

                    if (propertyInfo != null)
                    {
                        int tempOut = 0;
                        propertyInfo.SetValue(obj, Int32.TryParse(value, out tempOut) ? tempOut : value, null);
                    }
                    else if (fieldInfo != null)
                    {
                        int tempOut = 0;
                        try
                        {
                            fieldInfo.SetValue(obj, Int32.TryParse(value, out tempOut) ? tempOut : value);
                        }
                        catch
                        {
                            fieldInfo.SetValue(obj, Boolean.Parse(value));
                        }
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
