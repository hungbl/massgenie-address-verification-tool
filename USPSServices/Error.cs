using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace USPSServices
{
    public class Error
    {
        [XmlElement("Number")]
        public string Number { get; set; }
        [XmlElement("Source")]
        public string Source { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        [XmlElement("HelpFile")]
        public string HelpFile { get; set; }
        [XmlElement("FelpContext")]
        public string FelpContext { get; set; }
    }
}
