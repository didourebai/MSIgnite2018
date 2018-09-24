using NHibernate;
using TravelGuideTunisia.Business.Base.Interfaces;

namespace TravelGuideTunisia.Infrastructure.BaseContext
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private attributes

        /// <summary>
        /// Transaction attribute
        /// </summary>
        private readonly ITransaction _transaction;

        /// <summary>
        /// Current session factory.
        /// </summary>
        private readonly ISessionFactory _sessionFactory;

        #endregion

        #region Public attributes

        /// <summary>
        /// Obtain or define
        /// Current session factory.
        /// </summary>
        public ISession Session { get; private set; }

        #endregion

        #region Constructors

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Save database changes.
        /// </summary>
        public void Commit()
        {
            if (_transaction.IsActive)
                _transaction.Commit();
        }

        /// <summary>
        /// Rollback database changes.
        /// </summary>
        public void Rollback()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
        }

        /// <summary>
        /// Cleanup resources.
        /// </summary>
        public void Dispose()
        {
            Session.Dispose();
        }

        #endregion
    }
}
