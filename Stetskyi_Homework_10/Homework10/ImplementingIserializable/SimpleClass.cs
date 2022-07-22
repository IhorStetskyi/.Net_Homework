using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ImplementingIserializable
{
    [Serializable]
    public class SimpleClass : ISerializable, IXmlSerializable
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public bool Deserialized { get; set; }

        public SimpleClass()
        {
            
        }
        [JsonConstructor]
        public SimpleClass(int myProperty1, string myProperty2, bool deserialized)
        {
            MyProperty1 = myProperty1;
            MyProperty2 = myProperty2;
            Deserialized = true;
        }

        public SimpleClass(SerializationInfo info, StreamingContext context)
        {
            MyProperty1 = info.GetInt32("myProperty1");
            MyProperty2 = info.GetString("myProperty2");
            Deserialized = true;
        }

        #region ISerializable implementation
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("myProperty1", MyProperty1);
            info.AddValue("myProperty2", MyProperty2);
        }
        #endregion
        #region IXmlSerializable implementation
        public XmlSchema GetSchema()
        {
            return (null);
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            MyProperty1 = Int32.Parse(reader.GetAttribute("myProperty1"));
            MyProperty2 = reader.GetAttribute("myProperty2");
            Deserialized = true;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("myProperty1", MyProperty1.ToString());
            writer.WriteAttributeString("myProperty2", MyProperty2);
        }
        #endregion
    }
}
