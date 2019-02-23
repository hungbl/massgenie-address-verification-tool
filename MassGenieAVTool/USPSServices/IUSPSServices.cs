using MassGenieAVTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MassGenieAVTool.USPSServices
{
    public interface IUSPSServices
    {

        AddressValidateResponse AddressValidate(Config config, Address address);
        string ZipCodeLookup(Config config, Address address);
        string CityStateLookup(Config config, Address address);
        string TrackPackage(Config config, string trackingID);
        string ConvertXMLToJson(string input);
    }
}
