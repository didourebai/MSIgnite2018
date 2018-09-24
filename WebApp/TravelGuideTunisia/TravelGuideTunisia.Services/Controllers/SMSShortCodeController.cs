using System;
using System.Net;
using System.Net.Http;
using TravelGuideTunisia.Business.DomainServices.SMSCheck;
using TravelGuideTunisia.Business.Models.SMSCheck;
using Microsoft.AspNetCore.Mvc;

namespace TravelGuideTunisia.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSShortCodeController : ControllerBase
    {
        private readonly ISMSCheckDomainServices _sMSCheckDomainServices;

        public SMSShortCodeController(ISMSCheckDomainServices sMsCheckDomainServices)
        {
            if (sMsCheckDomainServices == null)
                throw new ArgumentNullException("sMsCheckDomainServices");

            _sMSCheckDomainServices = sMsCheckDomainServices;
        }
        /// <summary>
        /// Method to check the code
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        
        [HttpGet]
        public IActionResult CheckCode()
        {

            var codeCheckInfoDto = new CodeCheckRequestModel
            {
                Code = "Code",
                PhoneNumber = "",
                UserId = "",
                AppId = ""
            };

        
            var result = _sMSCheckDomainServices.CheckSMSCode(codeCheckInfoDto);
            var statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), result.StatusDetail.ToString());
            if (statusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);

            }
            return Ok(result);
        }

        /// <summary>
        /// Post New Code
        /// </summary>
        /// <param name="postNewCodeDTO">postNewCode DTO</param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.Route("create")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public HttpResponseMessage PostNewCode( )
        {

            var result = _sMSCheckDomainServices.PostNewCode(new PostNewCodeRequestModel()
            {
                AppId = "app 1",
                CodeLength = 7,
                MessageTemplate = "hello message",
                PhoneNumber = "123456789",
                Ttl = 1,
                UserId = "user 1"
            });
            var statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), result.StatusDetail.ToString());
            return new HttpResponseMessage(statusCode);
        }


    }
}
