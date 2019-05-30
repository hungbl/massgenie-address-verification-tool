using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USPSServices
{
    public class Template
    {
        public static string AddressValidateTemplate = "{0}/ShippingAPI.dll?API=Verify&XML=<AddressValidateRequest USERID=\"{1}\"><Revision>1</Revision><Address ID=\"0\"><Address1>{2}</Address1><Address2>{3}</Address2><City>{4}</City><State>{5}</State><Zip5>{6}</Zip5><Zip4></Zip4></Address></AddressValidateRequest>";
        public static string ZipCodeLookup = "{0}/ShippingAPI.dll?API=ZipCodeLookup&XML=<ZipCodeLookupRequest USERID=\"{1}\"><Address><Address1>{2}</Address1><Address2>{3}</Address2><City>{4}</City><State>{5}</State></Address></ZipCodeLookupRequest>";
        public static string CityStateLookup = "{0}/ShippingAPI.dll?API=CityStateLookup&XML=<CityStateLookupRequest USERID=\"{1}\"><ZipCode ID='0'><Zip5>{2}</Zip5></ZipCode></CityStateLookupRequest>";
    }
}
