using System;
using MassGenieAVTool.Model;
using MassGenieAVTool.USPSServices;
using MassGenieAVTool.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MassGenieAVTool.Controllers
{
    [Route("usps-services")]
    public class USPSServicesController : Controller
    {
        private readonly IUSPSServices _addressVerification;
        private readonly IUSPSServices _trackingVerification;
        private readonly ISerializer _serializer;
        public USPSServicesController(ISerializer serializer)
        {
            
            _addressVerification = new AddressVerification(serializer);
            _trackingVerification = new TrackingVerification();
        }

        [HttpPost]
        [Route("address-verify")]
        public IActionResult AddressVerify([FromBody]Address address)
        {
            string output = "";
            try
            {
                var config = GetConfig(address.UserID);
                var response = _addressVerification.AddressValidate(config, address);
                return new JsonResult(new
                {
                    data = JsonConvert.SerializeObject(response),
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
        public IActionResult ZipCodeLookup([FromBody]Address address)
        {
            string output = "";
            try
            {
                var config = GetConfig(address.UserID);
                output = _addressVerification.ZipCodeLookup(config, address);
                return new JsonResult(new
                {
                    data = output,
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
        public IActionResult CityStateLookup([FromBody]Address address)
        {
            string output = "";
            try
            {
                var config = GetConfig(address.UserID);
                output = _addressVerification.CityStateLookup(config, address);
                return new JsonResult(new
                {
                    data = output,
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

        [HttpGet]
        [Route("track-package/{userID}/{trackingID}")]
        public IActionResult TrackPackage(string userID, string trackingID)
        {
            string output = "";
            try
            {
                var config = GetConfig(userID);
                output = _trackingVerification.TrackPackage(config, trackingID);
                return new JsonResult(new
                {
                    data = output,
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

        private Config GetConfig(string userID)
        {
            return new Config
            {
                UserID = userID ?? "0",
                Host = "http://production.shippingapis.com"
            };
        }
    }
}