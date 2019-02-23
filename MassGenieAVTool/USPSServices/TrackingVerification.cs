using MassGenieAVTool.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace MassGenieAVTool.USPSServices
{
    public class TrackingVerification : IUSPSServices
    {
        public string TrackPackage(Config config, string trackingID)
        {
            var web = new WebClient();
            var template = Template.TrackingTemplate;
            var trackingUrl = string.Format(template, config.Host, config.UserID, trackingID);
            string resultXML = web.DownloadString(trackingUrl);
            return ConvertXMLToJson(resultXML);
        }

        public AddressValidateResponse AddressValidate(Config config, Address address)
        {
            throw new NotImplementedException();
        }

        public string CityStateLookup(Config config, Address address)
        {
            throw new NotImplementedException();
        }

        public string ConvertXMLToJson(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            input = input.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(input);

            return JsonConvert.SerializeXmlNode(xDoc);
        }

        public string ZipCodeLookup(Config config, Address address)
        {
            throw new NotImplementedException();
        }
    }
}
