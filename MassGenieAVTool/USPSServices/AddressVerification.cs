using MassGenieAVTool.Model;
using MassGenieAVTool.Utils;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Xml;

namespace MassGenieAVTool.USPSServices
{
    public class AddressVerification : IUSPSServices
    {
        private ISerializer _serializer;
        public AddressVerification(ISerializer serializer)
        {
            _serializer = serializer;
        }
        /// <summary>
        /// verify if address exist or not
        /// </summary>
        /// <param name="config"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public AddressValidateResponse AddressValidate(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.AddressValidateTemplate;
            var validateUrl = string.Format(template, config.Host, config.UserID, 
                                            address.Address1, address.Address2, address.City, address.State, address.Zip5);
            string resultXML = web.DownloadString(validateUrl);
            resultXML = resultXML.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
            var response = _serializer.Deserialize<AddressValidateResponse>(resultXML);
            if(response.Addresses == null || response.Addresses.Count == 0 || response.Addresses.First() == null)
            {
                response.StatusID = 2;
                response.Message = "There is an api error happended";
                return response;
            }

            var addressResponse = response.Addresses.First();

            if (addressResponse.Error != null)
            {
                if (addressResponse.Error.Description.Contains("Address Not Found") || addressResponse.Error.Description.Contains("Invalid"))
                {
                    response.StatusID = 0;
                    response.Message = "Address error or contain incorrect field";
                    return response;
                }

                response.StatusID = 2;
                response.Message = "Other Error";
                return response;
            }

            if (!address.Address1.Equals(addressResponse.Address1) & !address.Address1.Equals(addressResponse.Address2))
            {
                response.StatusID = 0;
                response.Message = "Address line 1 incorrect";
                return response;
            }

            if (!address.City.Equals(addressResponse.City)
                || !address.State.Equals(addressResponse.State)
                || !address.Zip5.Equals(addressResponse.Zip5))
            {
                response.StatusID = 0;
                response.Message = "Address have one or more incorrect field";
                return response;
            }

            response.StatusID = 2;
            response.Message = "Empty result";
            return response;

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
