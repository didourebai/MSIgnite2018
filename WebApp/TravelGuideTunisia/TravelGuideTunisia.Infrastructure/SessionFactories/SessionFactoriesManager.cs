using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Context;
using TravelGuideTunisia.Persistence.Base.Classes;
using TravelGuideTunisia.Persistence.Base.Interfaces;

namespace TravelGuideTunisia.Infrastructure.SessionFactories
{
    public class SessionFactoriesManager : ISessionFactoriesManager
    {
        #region Private attributes

        private IDictionary<string, ISessionFactory> _sessionFactoryDictionary;


        private IList<ISession> _openSessions;

        private static object _lock = new object();

        #endregion

        #region Constructors

        public SessionFactoriesManager()
        {
            lock (_lock)
            {
                _sessionFactoryDictionary = new Dictionary<string, ISessionFactory>();
                _openSessions = new List<ISession>();
            }

        }

        #endregion

        #region Interface Methods

        public IDictionary<string, ISessionFactory> GetSessionFactories()
        {
            lock (_lock)
            {
                return _sessionFactoryDictionary;
            }
        }

        public void AddSessionFactory(string sessionFactoryIdentifire, ISessionFactory sessionFactory)
        {
            lock (_lock)
            {
                _sessionFactoryDictionary.Add(sessionFactoryIdentifire, sessionFactory);
            }
        }

        public void AddSessionFactory(string sessionFactoryIdentifire, string dbmsTypeAsString, string connectionStringName, List<Type> listOfEntityMapTypes, bool withLog = true)
        {
            lock (_lock)
            {
                var sessionFactory = SessionFactoryBuilder.BuildSessionFactory(dbmsTypeAsString, connectionStringName, listOfEntityMapTypes, withLog);
                _sessionFactoryDictionary.Add(sessionFactoryIdentifire, sessionFactory);
            }
            //return sessionFactory;
        }

        public void AddSessionFactoryForNamespaceOf<T>(ISessionFactory sessionFactory) where T : BasicEntity
        {
            lock (_lock)
            {
                var entityNamespace = typeof(T).Namespace;
                _sessionFactoryDictionary.Add(entityNamespace, sessionFactory);
            }
        }

        public void AddSessionFactoryForNamespaceOf<E, M>(string dbmsTypeAsString, string connectionStringName, bool withLog = true, bool create = false, bool update = false)
        //where E : BasicEntity
        //where M : class
        {
            lock (_lock)
            {
                var entityInterfaceFullName = typeof(E).FullName;
                var listOfEntityMap = typeof(M).Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(M))).ToList();
                var sessionFactory = SessionFactoryBuilder.BuildSessionFactory(dbmsTypeAsString, connectionStringName, listOfEntityMap, withLog, create, update);
                _sessionFactoryDictionary.Add(entityInterfaceFullName, sessionFactory);
                //return sessionFactory;
            }
        }

        public ISessionFactory GetEntitySessionFactory<T>(out string sessionFactoryKey) where T : BasicEntity
        {
            lock (_lock)
            {
                //sessionFactoryKey = string.Empty;
                foreach (var item in typeof(T).GetInterfaces())
                {
                    if (_sessionFactoryDictionary.Any(s => s.Key == item.FullName))
                    {
                        sessionFactoryKey = item.FullName;
                        return _sessionFactoryDictionary[item.FullName];
                    }
                }
                sessionFactoryKey = String.Empty;
                return null;
            }
        }

        public ISession GetCurrentSession<T>() where T : BasicEntity
        {
            lock (_lock)
            {
                var sessionFactoryKey = string.Empty;
                var sessionFactory = GetEntitySessionFactory<T>(out sessionFactoryKey);
                if (sessionFactory == null)
                {
                    return null;
                }

                if (!CurrentSessionContext.HasBind(sessionFactory))
                {
                    var session = sessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);
                    _openSessions.Add(session);

                }

                return sessionFactory.GetCurrentSession();
            }
        }

        public ISessionFactory GetEntitySessionFactory<T>() where T : BasicEntity
        {
            lock (_lock)
            {
                foreach (var item in typeof(T).GetInterfaces())
                {
                    if (_sessionFactoryDictionary.Any(s => s.Key == item.FullName))
                    {
                        return _sessionFactoryDictionary[item.FullName];
                    }
                }
                //var sessionFactory = _sessionFactoryDictionary. [sessionfactoryIdentifire];
                return null;
            }
        }



        #endregion


        public void AddSessionFactory(string sessionFactoryIdentifire, object sessionFactory)
        {
            lock (_lock)
            {
                AddSessionFactory(sessionFactoryIdentifire, sessionFactory as ISessionFactory);
            }
        }


        public void AddSessionFactoryForNamespaceOf<T>(object sessionFactory) where T : BasicEntity
        {
            lock (_lock)
            {
                AddSessionFactoryForNamespaceOf<T>(sessionFactory as ISessionFactory);
            }

        }


        IDictionary<string, object> ISessionFactoriesManager.GetSessionFactories()
        {
            lock (_lock)
            {
                var result = new Dictionary<string, object>();
                foreach (var item in _sessionFactoryDictionary)
                {
                    result.Add(item.Key, item.Value);
                }
                return result;
            }

        }

        object ISessionFactoriesManager.GetEntitySessionFactory<T>()
        {
            lock (_lock)
            {
                return GetEntitySessionFactory<T>() as Object;
            }
        }

        object ISessionFactoriesManager.GetEntitySessionFactory<T>(out string sessionFactoryKey)
        {
            lock (_lock)
            {
                sessionFactoryKey = string.Empty;
                return GetEntitySessionFactory<T>(out sessionFactoryKey) as Object;
            }
        }

        object ISessionFactoriesManager.GetCurrentSession<T>()
        {
            lock (_lock)
            {
                return GetCurrentSession<T>() as object;
            }
        }

        void ISessionFactoriesManager.CommitAllTransactions()
        {
            lock (_lock)
            {
                foreach (var session in _openSessions)
                {
                    if (IsActiveSession(session))
                    {
                        session.Flush();
                        session.Transaction.Commit();
                        session.Close();
                    }


                    if (CurrentSessionContext.HasBind(session.SessionFactory))
                        CurrentSessionContext.Unbind(session.SessionFactory);



                }

                _openSessions.Clear();
            }
        }

        void ISessionFactoriesManager.RollbackAllTransactions()
        {
            lock (_lock)
            {
                foreach (var session in _openSessions)
                {
                    if (IsActiveSession(session))
                        session.Transaction.Rollback();

                    if (session != null && CurrentSessionContext.HasBind(session.SessionFactory))
                        CurrentSessionContext.Unbind(session.SessionFactory);



                }

                _openSessions.Clear();
            }
        }


        #region Private Methods

        private static bool IsActiveSession(ISession session)
        {
            lock (_lock)
            {
                return session != null && session.Transaction != null && session.Transaction.IsActive;
            }
        }

        #endregion

    }
}
