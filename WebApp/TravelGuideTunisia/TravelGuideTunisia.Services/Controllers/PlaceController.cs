using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TravelGuideTunisia.Business.DomainServices.Place;
using TravelGuideTunisia.Business.Models.Place;
using TravelGuideTunisia.Business.Models.SMSCheck;

namespace TravelGuideTunisia.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : Controller
    {
        private readonly IPlaceDomainServices _placeDomainServices;

        public PlaceController(IPlaceDomainServices placeDomainServices)
        {
            _placeDomainServices = placeDomainServices ?? throw new ArgumentNullException(nameof(placeDomainServices));
        }

        [HttpGet]
        public IActionResult GetPlaces()
        {
            var result = _placeDomainServices.GetPlaces();
            var statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), result.StatusDetail.ToString());
            if (statusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);

            }
            return Ok(result);
        }
        [Route("create")]
        [HttpPost]
        public IActionResult PostNewCode(PostPlaceResultModel postPlaceResultModel)
        {

            var result = _placeDomainServices.PostNewPlace(postPlaceResultModel);

            var statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), result.StatusDetail.ToString());
            if (statusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);

            }
            return Ok(result);
        }

    }
}