using System;
using RH.Standards.Domain;
using TravelGuideTunisia.Business.Models.Hotel;
using TravelGuideTunisia.Persistence.Base.Interfaces;

namespace TravelGuideTunisia.Business.DomainServices.Hotel
{
    public class HotelDomainServices : IHotelDomainServices
    {
        #region Private Properties

        private readonly IRepository<Persistence.Entities.TravelGuide.Hotel> _hotelRegistrationRepository;

        public HotelDomainServices(IRepository<Persistence.Entities.TravelGuide.Hotel> hotelRegistrationRepository)
        {
            _hotelRegistrationRepository = hotelRegistrationRepository ?? throw new ArgumentNullException(nameof(hotelRegistrationRepository));
        }

        #endregion

        public ResultOfType<HotelResultModel> GetHotels(int skip = 0, int take = 0)
        {
            throw new System.NotImplementedException();
        }

        public ResultOfType<PostHotelResultModel> PostNewHotel(PostHotelResultModel convertToPostHotelResultModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
