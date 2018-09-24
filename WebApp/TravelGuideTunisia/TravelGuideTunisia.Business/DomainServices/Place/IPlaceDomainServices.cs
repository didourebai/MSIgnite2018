using RH.Standards.Domain;
using TravelGuideTunisia.Business.Models;
using TravelGuideTunisia.Business.Models.Place;

namespace TravelGuideTunisia.Business.DomainServices.Place
{
    public interface IPlaceDomainServices
    {
        ResultOfType<ResultListModel<PlaceResultModel>> GetPlaces(int skip = 0, int take = 0);
        ResultOfType<PostPlaceResultModel> PostNewPlace(PostPlaceResultModel convertToPostPlaceResultModel);
    }
}
