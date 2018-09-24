using RH.Standards.Domain;
using TravelGuideTunisia.Business.Models.User;

namespace TravelGuideTunisia.Business.DomainServices.User
{
    public interface IUserDomainServices
    {
        ResultOfType<UserResultModel> GetUsers(int skip = 0, int take = 0);
        ResultOfType<PostUserResultModel> PostNewUser(PostUserResultModel convertToPostPlaceResultModel);
    }
}
