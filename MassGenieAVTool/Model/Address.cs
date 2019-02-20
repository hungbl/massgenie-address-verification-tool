using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassGenieAVTool.Model
{
    public class Address
    {
        public string FirmName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Urbanization { get; set; }
        public string Zip5 { get; set; }
        public string Zip4 { get; set; }
        public string DeliveryPoint { get; set; }
        public string CarrierRoute { get; set; }
        public string Error { get; set; }
        public string UserID { get; set; }
    }
}
