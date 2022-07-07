using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ImplementingIserializable
{
    [Serializable]
    public class SimpleClass : ISerializable, IXmlSerializable
    {
        public int myProperty1 { get; set; }
        public string myProperty2 { get; set; }
        public bool deserialized { get; set; }

        public SimpleClass()
        {

        }

        public SimpleClass(SerializationInfo info, StreamingContext context)
        {
            myProperty1 = info.GetInt32("myProperty1");
            myProperty2 = info.GetString("myProperty2");
            deserialized = true;
        }

        #region ISerializable implementation
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("myProperty1", myProperty1);
            info.AddValue("myProperty2", myProperty2);
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
            myProperty1 = Int32.Parse(reader.GetAttribute("myProperty1"));
            myProperty2 = reader.GetAttribute("myProperty2");
            deserialized = true;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("myProperty1", myProperty1.ToString());
            writer.WriteAttributeString("myProperty2", myProperty2);
        }
        #endregion
    }
}
