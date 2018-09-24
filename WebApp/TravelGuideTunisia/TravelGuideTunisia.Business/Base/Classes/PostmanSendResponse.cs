using System.Net;

namespace TravelGuideTunisia.Business.Base.Classes
{
    public class PostmanSendResponse
    {
        public string ResponseData { get; set; }

        public HttpStatusCode Status { get; set; }
    }
}
