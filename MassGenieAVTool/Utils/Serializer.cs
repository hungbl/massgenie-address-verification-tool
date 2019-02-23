using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MassGenieAVTool.Utils
{
    public class Serializer : ISerializer
    {

        public T Deserialize<T>(string input) where T : class
        {
            var ser = new XmlSerializer(typeof(T));
            using(StringReader sr = new StringReader(input))
            {
                var xmlReader = new XmlTextReader(sr);
                var obj = (T)ser.Deserialize(xmlReader);
                xmlReader.Close();
                sr.Close();
                return obj;
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            throw new NotImplementedException();
        }
    }
}
