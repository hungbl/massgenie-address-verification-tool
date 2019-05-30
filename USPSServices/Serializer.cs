using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace USPSServices
{
    public static class Serializer
    {
        public static T Deserialize<T>(string input) where T : class
        {
            var ser = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(input))
            {
                var xmlReader = new XmlTextReader(sr);
                var obj = (T)ser.Deserialize(xmlReader);
                xmlReader.Close();
                sr.Close();
                return obj;
            }
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            throw new NotImplementedException();
        }
    }
}
