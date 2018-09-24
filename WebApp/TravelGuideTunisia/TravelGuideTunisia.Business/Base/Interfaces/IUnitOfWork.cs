using System;

namespace TravelGuideTunisia.Business.Base.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit database changes
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback database transactions
        /// </summary>
        void Rollback();
    }
}
