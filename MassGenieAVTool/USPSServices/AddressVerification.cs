using MassGenieAVTool.Model;
using Newtonsoft.Json;
using System.Net;
using System.Xml;

namespace MassGenieAVTool.USPSServices
{
    public class AddressVerification : IUSPSServices
    {
        /// <summary>
        /// verify if address exist or not
        /// </summary>
        /// <param name="config"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public string AddressValidate(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.AddressValidateTemplate;
            var validateUrl = string.Format(template, config.Host, config.UserID, 
                                            address.Address1, address.Address2, address.City, address.State, address.Zip5);
            string resultXML = web.DownloadString(validateUrl);
            
            return ConvertXMLToJson(resultXML);
        }

        /// <summary>
        /// find zip code base on other address information
        /// </summary>
        /// <param name="config"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public string ZipCodeLookup(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.ZipCodeLookup;
            var zipCodeLookupUrl = string.Format(template, config.Host, config.UserID, address.Address1, address.Address1, address.City, address.State);
            string resultXML = web.DownloadString(zipCodeLookupUrl);
            return ConvertXMLToJson(resultXML);
        }

        /// <summary>
        /// find city and state base on zip code
        /// </summary>
        /// <param name="config"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public string CityStateLookup(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.CityStateLookup;
            var cityStateLookup = string.Format(template, config.Host, config.UserID, address.Zip5);
            string resultXML = web.DownloadString(cityStateLookup);
            return ConvertXMLToJson(resultXML);
        }

        public string TrackPackage(Config config, string trackingID)
        {
            throw new System.NotImplementedException();
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
    }
}
