using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MassGenieAVTool.Model
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
