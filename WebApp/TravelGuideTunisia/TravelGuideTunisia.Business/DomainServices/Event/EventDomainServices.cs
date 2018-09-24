using System;
using System.Collections.Generic;
using RH.Standards.Domain;
using TravelGuideTunisia.Business.Factories;
using TravelGuideTunisia.Business.Helpers;
using TravelGuideTunisia.Business.Models;
using TravelGuideTunisia.Business.Models.Event;
using TravelGuideTunisia.Business.Models.Place;
using TravelGuideTunisia.Persistence.Base.Interfaces;

namespace TravelGuideTunisia.Business.DomainServices.Event
{
    public class EventDomainServices : IEventDomainServices
    {
        #region Private Properties
        private readonly IRepository<Persistence.Entities.TravelGuide.Event> _eventRepository;

        public EventDomainServices(IRepository<Persistence.Entities.TravelGuide.Event> eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        #endregion

        public ResultOfType<ResultListModel<EventResultModel>> GetEvents(int skip = 0, int take = 0)
        {
            var absoluteTotalCount = _eventRepository.GetCount();


            var queryResult = absoluteTotalCount <= 0
                ? null
                : _eventRepository.GetSkipAndTake(skip, take, ProjectionFactory.GetProjectionForEvent<Persistence.Entities.TravelGuide.Event>());

            var totalCount = absoluteTotalCount;

            var totalPages = (take != 0)
                ? (int)Math.Ceiling((double)totalCount / take)
                : (skip == 0
                    ? 1
                    : 0);


            var listOfResultModel = new List<EventResultModel>();

            if (queryResult != null)
                foreach (var eevent in queryResult)
                {
                    listOfResultModel.Add(ModelFactory.ToEventResultModel(eevent));
                }

            return ResponseFor<ResultListModel<EventResultModel>>.AsOK(new ResultListModel<EventResultModel>(listOfResultModel, absoluteTotalCount, totalCount, totalPages));
        }

        public ResultOfType<PostEventResultModel> PostNewEvent(PostEventResultModel convertToPostEventResultModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
