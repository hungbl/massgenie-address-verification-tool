using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MassGenieAVTool.Controllers
{
    [Route("usps-services")]
    public class USPSServicesController : Controller
    {
        [HttpPost]
        [Route("address-verify")]
        public ActionResult AddressVerify([FromBody]Address address)
        {
            string output = "";
            var config = new Config
            {
                UserID = address.UserID ?? "0",
                Host = "http://production.shippingapis.com"
            };
            output = AddressVerification.AddressValidate(config, address);
            output = output.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(output);

            string json = JsonConvert.SerializeXmlNode(doc);
            try
            {

                return new JsonResult(new
                {
                    data = json,
                    status = "success",
                    statusCode = 1,
                    message = ""
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    data = output,
                    status = "error",
                    statusCode = 0,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("zip-code-lookup")]
        public ActionResult ZipCodeLookup([FromBody]Address address)
        {
            string output = "";
            var config = new Config
            {
                UserID = address.UserID ?? "0",
                Host = "http://production.shippingapis.com"
            };
            output = AddressVerification.ZipCodeLookup(config, address);
            output = output.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(output);

            string json = JsonConvert.SerializeXmlNode(doc);
            try
            {

                return new JsonResult(new
                {
                    data = json,
                    status = "success",
                    statusCode = 1,
                    message = ""
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    data = output,
                    status = "error",
                    statusCode = 0,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("city-state-lookup")]
        public ActionResult CityStateLookup([FromBody]Address address)
        {
            string output = "";
            try
            {
                var config = new Config
                {
                    UserID = address.UserID ?? "0",
                    Host = "http://production.shippingapis.com"
                };
                output = AddressVerification.CityStateLookup(config, address);
                output = output.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(output);

                string json = JsonConvert.SerializeXmlNode(doc);
                return new JsonResult(new
                {
                    data = json,
                    status = "success",
                    statusCode = 1,
                    message = ""
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    data = output,
                    status = "error",
                    statusCode = 0,
                    message = ex.Message
                });
            }
        }
    }
}