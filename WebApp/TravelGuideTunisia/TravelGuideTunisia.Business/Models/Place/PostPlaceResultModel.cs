using TravelGuideTunisia.Business.Validation;

namespace TravelGuideTunisia.Business.Models.Place
{
    public class PostPlaceResultModel : SelfValidationModel
    {
        public string Descritpion { get; set; }
        public string Governorate { get; set; }
        public string Address { get; set; }
        public string History { get; set; }
    }
}
