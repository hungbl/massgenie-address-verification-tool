using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MassGenieAVTool
{
    public static class AddressVerification
    {
        public static string AddressValidate(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.AddressValidateTemplate;
            var validateUrl = string.Format(template, config.Host, config.UserID, 
                                            address.Address1, address.Address2, address.City, address.State, address.Zip5);
            string resultXML = web.DownloadString(validateUrl);
            return resultXML;
        }

        public static string ZipCodeLookup(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.ZipCodeLookup;
            var zipCodeLookupUrl = string.Format(template, config.Host, config.UserID, address.Address1, address.Address1, address.City, address.State);
            string resultXML = web.DownloadString(zipCodeLookupUrl);
            return resultXML;
        }

        public static string CityStateLookup(Config config, Address address)
        {
            var web = new WebClient();
            var template = Template.CityStateLookup;
            var cityStateLookup = string.Format(template, config.Host, config.UserID, address.Zip5);
            string resultXML = web.DownloadString(cityStateLookup);
            return resultXML;
        }
    }
}
