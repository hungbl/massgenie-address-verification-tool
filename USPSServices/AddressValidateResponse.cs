using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace USPSServices
{
    [XmlRoot("AddressValidateResponse")]
    public class AddressValidateResponse
    {
        [XmlElement("Address")]
        public List<Address> Addresses { get; set; }
        public int StatusID { get; set; }
        public string Message { get; set; }
    }
}
