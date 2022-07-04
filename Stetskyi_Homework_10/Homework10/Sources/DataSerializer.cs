using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Sources
{
    public class DataSerializer
    {
        //BINARY
        public void BinarySerialize(object data, string filePath)
        {
            FileStream filestream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            filestream = File.Create(filePath);
            bf.Serialize(filestream, data);
            filestream.Close();

        }
        public T BinaryDeserialize<T>(string filePath)
        {
            object obj = null;
            FileStream filestream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                filestream = File.OpenRead(filePath);
                obj = bf.Deserialize(filestream);
                filestream.Close();
            }
            return (T)obj;
        }

        //XML
        public void XMLSerialize(object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            TextWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();

        }
        public T XMLDeserialize<T>(string filePath)
        {
            object obj = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return (T)obj;
        }

        //JSON Newtonsoft
        public void JSONSerializeNewtonsoft(object data, string filePath)
        {
            Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            StreamWriter streamWriter = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            jsonSerializer.Serialize(jsonWriter, data);
            jsonWriter.Close();
            streamWriter.Close();
        }
        public T JSONDeserializeNewtonsoft<T>(string filePath)
        {
            JObject jobj = null;
            object obj = null;
            Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            if (File.Exists(filePath))
            {
                StreamReader streamReader = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(streamReader);
                jobj = (JObject)jsonSerializer.Deserialize(jsonReader);
                jsonReader.Close();
                streamReader.Close();
            }
            obj = jobj.ToObject(typeof(T));
            return (T)obj;
        }

        //JSON System.Text.Json (as per study example)
        public void JSONSerialize(object data, string filePath)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(data);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, jsonString);
        }
        public T JSONDeserialize<T>(string filePath)
        {
            object obj = null;
            if (File.Exists(filePath))
            {
                StreamReader streamReader = new StreamReader(filePath);
                string f = streamReader.ReadToEnd();
                obj = System.Text.Json.JsonSerializer.Deserialize<T>(f);
                streamReader.Close();
            }
            return (T)obj;
        }

        //CUSTOM
        public void CustomSerialize(object data, string filePath)
        {

            CustomSerializer customSerializer = new CustomSerializer(data.GetType());
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            FileStream fileStream = File.Create(filePath);
            customSerializer.Serialize(fileStream, data);
            fileStream.Close();
        }
        public T CustomDeserialize<T>(string filePath)
        {
            object obj = null;
            CustomSerializer customSerializer = new CustomSerializer(typeof(T));
            if (File.Exists(filePath))
            {
                FileStream fileStream = File.OpenRead(filePath);
                obj = customSerializer.Deserialize(fileStream);
                fileStream.Close();
            }
            return (T)obj;
        }
    }
}
