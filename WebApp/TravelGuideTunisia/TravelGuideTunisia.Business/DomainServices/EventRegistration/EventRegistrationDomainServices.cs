using System;
using System.Collections.Generic;
using System.Linq;
using RH.Standards.Domain;
using TravelGuideTunisia.Business.Factories;
using TravelGuideTunisia.Business.Helpers;
using TravelGuideTunisia.Business.Models;
using TravelGuideTunisia.Business.Models.EventRegistration;
using TravelGuideTunisia.Persistence.Base.Interfaces;

namespace TravelGuideTunisia.Business.DomainServices.EventRegistration
{
    public class EventRegistrationDomainServices: IEventRegistrationDomainServices
    {
        #region Private Properties

        private readonly IRepository<Persistence.Entities.TravelGuide.EventRegistration> _eventRegistrationRepository;
        private readonly IRepository<Persistence.Entities.TravelGuide.User> _userRegistrationRepository;
        private readonly IRepository<Persistence.Entities.TravelGuide.Event> _eventRepository;
        #endregion
        public EventRegistrationDomainServices(IRepository<Persistence.Entities.TravelGuide.EventRegistration> eventRegistrationRepository, IRepository<Persistence.Entities.TravelGuide.User> userRegistrationRepository, IRepository<Persistence.Entities.TravelGuide.Event> eventRepository)
        {
            _eventRegistrationRepository = eventRegistrationRepository ?? throw new ArgumentNullException(nameof(eventRegistrationRepository));
            _userRegistrationRepository = userRegistrationRepository ?? throw new ArgumentNullException(nameof(userRegistrationRepository));
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

     
        
        public ResultOfType<ResultListModel<EventRegistrationResultModel>> GetEventRegistrations(int skip = 0,int take = 0)
        {
            var absoluteTotalCount = _eventRegistrationRepository.GetCount();


            var queryResult = absoluteTotalCount <= 0
                ? null
                : _eventRegistrationRepository.GetSkipAndTake(skip, take, ProjectionFactory.GetProjectionForEventRegistration<Persistence.Entities.TravelGuide.EventRegistration>());

            var totalCount = absoluteTotalCount;

            var totalPages = (take != 0)
                ? (int)Math.Ceiling((double)totalCount / take)
                : (skip == 0
                    ? 1
                    : 0);


            var listOfResultModel = new List<EventRegistrationResultModel>();

            foreach (var client in queryResult)
            {
                listOfResultModel.Add(ModelFactory.ToEventRegistrationResultModel(client));
            }

            return ResponseFor<ResultListModel<EventRegistrationResultModel>>.AsOK(new ResultListModel<EventRegistrationResultModel>(listOfResultModel, absoluteTotalCount, totalCount, totalPages));
        }

        public ResultOfType<PostEventRegistrationResultModel> PostNewEventRegistration(PostEventRegistrationResultModel postEventRegistrationModel)
        {
            var varlidationErrorResponse = ValidatePostNewEventRegistrationRequsetModel(postEventRegistrationModel);
            if (varlidationErrorResponse != null)
            {
                return varlidationErrorResponse;
            }

            var user = _userRegistrationRepository.GetSkipAndTake(0, 0).FirstOrDefault(u => u.UserName.Equals(postEventRegistrationModel.UserName));
            if (user == null)
            {
                return   ResponseFor<PostEventRegistrationResultModel>.AsBadRequest(EErrorType.VALIDATION_FAILURE,"User not found!");
            }

            var events = _eventRepository.GetSkipAndTake(0, 0).FirstOrDefault(u => u.Title.Equals(postEventRegistrationModel.EventTitle));
            if (events == null)
            {
                return ResponseFor<PostEventRegistrationResultModel>.AsBadRequest(EErrorType.VALIDATION_FAILURE, "Event not found!");
            }
            //Post new line in the table SMS_SHORT_CODE
            var eventRegistration = new Persistence.Entities.TravelGuide.EventRegistration
            {
                 User = user,
                 Event = events

            };
            _eventRegistrationRepository.Add(eventRegistration);
           
            return ResponseFor<PostEventRegistrationResultModel>.AsOK(postEventRegistrationModel);
        }

        private ResultOfType<PostEventRegistrationResultModel> ValidatePostNewEventRegistrationRequsetModel(PostEventRegistrationResultModel postEventRegistrationModel)
        {
            if (postEventRegistrationModel.AutoValidation_IsNotValid)
            {
                return ResponseFor<PostEventRegistrationResultModel>.AsBadRequest(EErrorType.VALIDATION_FAILURE, postEventRegistrationModel.AutoValidation_ErrorMessage);
            }

            return null;
        }
    }
}
