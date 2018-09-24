using RH.Standards.Domain;

using TravelGuideTunisia.Business.Models.Hotel;

namespace TravelGuideTunisia.Business.DomainServices.Hotel
{
    public interface IHotelDomainServices
    {
        ResultOfType<HotelResultModel> GetHotels(int skip = 0, int take = 0);
        ResultOfType<PostHotelResultModel> PostNewHotel(PostHotelResultModel convertToPostHotelResultModel);
    }
}
