using System;
using System.Collections.Generic;
using RH.Standards.Domain;
using TravelGuideTunisia.Business.Factories;
using TravelGuideTunisia.Business.Helpers;
using TravelGuideTunisia.Business.Models;
using TravelGuideTunisia.Business.Models.Place;
using TravelGuideTunisia.Persistence.Base.Interfaces;

namespace TravelGuideTunisia.Business.DomainServices.Place
{
    public class PlaceDomainServices : IPlaceDomainServices
    {
        #region Private Properties

        private readonly IRepository<Persistence.Entities.TravelGuide.Place> _placeRepository;

        public PlaceDomainServices(IRepository<Persistence.Entities.TravelGuide.Place> placeRepository)
        {
            _placeRepository = placeRepository ?? throw new ArgumentNullException(nameof(placeRepository));
        }

        #endregion 

        public ResultOfType<ResultListModel<PlaceResultModel>> GetPlaces(int skip = 0, int take = 0)
        {
            var absoluteTotalCount = _placeRepository.GetCount();


            var queryResult = absoluteTotalCount <= 0
                ? null
                : _placeRepository.GetSkipAndTake(skip, take, ProjectionFactory.GetProjectionForPlace<Persistence.Entities.TravelGuide.Place>());

            var totalCount = absoluteTotalCount;

            var totalPages = (take != 0)
                ? (int)Math.Ceiling((double)totalCount / take)
                : (skip == 0
                    ? 1
                    : 0);


            var listOfResultModel = new List<PlaceResultModel>();

            if (queryResult != null)
                foreach (var place in queryResult)
                {
                    listOfResultModel.Add(ModelFactory.ToPlaceResultModel(place));
                }

            return ResponseFor<ResultListModel<PlaceResultModel>>.AsOK(new ResultListModel<PlaceResultModel>(listOfResultModel, absoluteTotalCount, totalCount, totalPages));
        }

        public ResultOfType<PostPlaceResultModel> PostNewPlace(PostPlaceResultModel convertToPostPlaceResultModel)
        {
            var varlidationErrorResponse = ValidatePlaceRequsetModel(convertToPostPlaceResultModel);
            if (varlidationErrorResponse != null)
            {
                return varlidationErrorResponse;
            }

          
            var eventRegistration = new Persistence.Entities.TravelGuide.Place()
            {
                Address = convertToPostPlaceResultModel.Address,
                Descritpion = convertToPostPlaceResultModel.Address,
                History = convertToPostPlaceResultModel.History,
                Governorate = convertToPostPlaceResultModel.Governorate
            };
            _placeRepository.Add(eventRegistration);

            return ResponseFor<PostPlaceResultModel>.AsOK(convertToPostPlaceResultModel);
        }

        private ResultOfType<PostPlaceResultModel> ValidatePlaceRequsetModel(PostPlaceResultModel postPlaceResultModel)
        {
            if (postPlaceResultModel.AutoValidation_IsNotValid)
            {
                return ResponseFor<PostPlaceResultModel>.AsBadRequest(EErrorType.VALIDATION_FAILURE, postPlaceResultModel.AutoValidation_ErrorMessage);
            }

            return null;
        }
    }
}
