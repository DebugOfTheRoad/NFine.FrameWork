using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace NFine.Code
{
    public class Serialize
    {
        public static byte[] GetBytes(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            MemoryStream serializationStream = new MemoryStream();
            new BinaryFormatter().Serialize(serializationStream, obj);
            serializationStream.Position = 0L;
            byte[] buffer = new byte[serializationStream.Length];
            serializationStream.Read(buffer, 0, buffer.Length);
            serializationStream.Close();
            return buffer;
        }

        public static XmlDocument GetXmlDoc(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            serializer.Serialize((TextWriter)writer, obj);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            writer.Close();
            return doc;
        }

        public static T GetObject<T>(byte[] obj)
        {
            if (obj == null)
            {
                return default(T);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(obj);
            return (T)formatter.Deserialize(stream);
        }

        public static T GetObject<T>(XmlDocument doc)
        {
            if (doc == null)
            {
                return default(T);
            }
            XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }
    }
}
