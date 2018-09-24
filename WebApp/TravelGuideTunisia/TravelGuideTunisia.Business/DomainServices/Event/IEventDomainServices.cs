using RH.Standards.Domain;
using TravelGuideTunisia.Business.Models;
using TravelGuideTunisia.Business.Models.Event;

namespace TravelGuideTunisia.Business.DomainServices.Event
{
    public interface IEventDomainServices
    {
        ResultOfType<ResultListModel<EventResultModel>> GetEvents(int skip =0, int take =0);
        ResultOfType<PostEventResultModel> PostNewEvent(PostEventResultModel convertToPostEventResultModel);
    }
}
