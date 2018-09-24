using RH.Standards.Domain;
using TravelGuideTunisia.Business.Models;
using TravelGuideTunisia.Business.Models.EventRegistration;

namespace TravelGuideTunisia.Business.DomainServices.EventRegistration
{
    public interface IEventRegistrationDomainServices
    {
        ResultOfType<ResultListModel<EventRegistrationResultModel>> GetEventRegistrations(int skip = 0, int take = 0);
        ResultOfType<PostEventRegistrationResultModel> PostNewEventRegistration(PostEventRegistrationResultModel convertToPostEventRegistrationModel);
    }
}
