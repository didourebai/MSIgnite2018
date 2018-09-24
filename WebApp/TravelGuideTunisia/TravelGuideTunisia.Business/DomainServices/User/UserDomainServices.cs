using System;
using RH.Standards.Domain;
using TravelGuideTunisia.Business.Models.User;
using TravelGuideTunisia.Persistence.Base.Interfaces;

namespace TravelGuideTunisia.Business.DomainServices.User
{
    public class UserDomainServices: IUserDomainServices
    {
        #region Private Properties

        private readonly IRepository<Persistence.Entities.TravelGuide.User> _userRegistrationRepository;

        public UserDomainServices(IRepository<Persistence.Entities.TravelGuide.User> userRegistrationRepository)
        {
            _userRegistrationRepository = userRegistrationRepository ?? throw new ArgumentNullException(nameof(userRegistrationRepository));
        }

        #endregion  
        public ResultOfType<UserResultModel> GetUsers(int skip = 0, int take = 0)
        {
            throw new System.NotImplementedException();
        }

        public ResultOfType<PostUserResultModel> PostNewUser(PostUserResultModel convertToPostPlaceResultModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
