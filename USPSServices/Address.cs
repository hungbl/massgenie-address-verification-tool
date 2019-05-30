using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace USPSServices
{
    public class Address
    {
        public string FirmName { get; set; }
        [XmlElement("Address1")]
        public string Address1 { get; set; }
        [XmlElement("Address2")]
        public string Address2 { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("State")]
        public string State { get; set; }
        public string Urbanization { get; set; }
        [XmlElement("Zip5")]
        public string Zip5 { get; set; }
        public string Zip4 { get; set; }
        public string DeliveryPoint { get; set; }
        public string CarrierRoute { get; set; }
        [XmlElement("Error")]
        public Error Error { get; set; }
        public string UserID { get; set; }
        [XmlElement("DPVConfirmation")]
        public string DPVConfirmation { get; set; }
    }
}
