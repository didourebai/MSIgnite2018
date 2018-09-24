using System;
using System.Linq.Expressions;
using TravelGuideTunisia.Persistence.Base.QueryCriteria;
using TravelGuideTunisia.Persistence.Entities.TravelGuide;

namespace TravelGuideTunisia.Business.Factories
{
    public class ProjectionFactory
    {
        #region Anagrafica Clienti
     
        #endregion

        public static Expression<Func<AC, object>>[] GetProjectionForEventRegistration<AC>() where AC : EventRegistration
        {
            return new Expression<Func<AC, object>>[]
            {
                a => a.Event,
                a => a.User,
                a => a.Id
            };
        }

        public static Expression<Func<AC, object>>[] GetProjectionForPlace<AC>() where AC : Place
        {
            return new Expression<Func<AC, object>>[]
            {
                a => a.Address,
                a => a.Descritpion,
                a => a.Governorate,
                a => a.History,
                a => a.Id
            };
        }

        public static Expression<Func<AC, object>>[] GetProjectionForEvent<AC>() where AC: Event
        {
            return new Expression<Func<AC, object>>[]
            {
                a=>a.Title,
                a=>a.Id,
                a=>a.Date,
                a=>a.Descritpion,
                a=>a.IsCancelled,
                a=>a.MaxRegistrationCount,
            };
        }
    }
}
