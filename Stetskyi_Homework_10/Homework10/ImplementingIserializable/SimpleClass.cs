using System;

using System.Runtime.Serialization;

namespace ImplementingIserializable
{
    [Serializable]
    public class SimpleClass : ISerializable
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }

        public bool deserialized;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("prop1", MyProperty1);
            info.AddValue("prop2", MyProperty2);
        }

        public SimpleClass(SerializationInfo info, StreamingContext context)
        {
            MyProperty1 = info.GetInt32("prop1");
            MyProperty2 = info.GetString("prop2");
            deserialized = true;
        }

        public SimpleClass()
        {
        }
    }
}
