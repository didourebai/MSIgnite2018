using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelGuideTunisia.Infrastructure.Helpers;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using RH.CrossCutting.Logging;
using Shocos.L6_Infrastructure.Helpers;
using TravelGuideTunisia.Persistence.Base.Classes;
using TravelGuideTunisia.Persistence.Base.Interfaces;
using TravelGuideTunisia.Persistence.Base.QueryCriteria;
using LinqExpressions = System.Linq.Expressions.Expression;

namespace TravelGuideTunisia.Infrastructure.BaseContext
{
    public class Repository<T> : IRepository<T> where T : BasicEntity
    {
        #region Private Attributes

        /// <summary>
        /// Define the current session factory.
        /// </summary>
        //private readonly ISessionFactory _sessionFactory;
        private readonly ISessionFactoriesManager _sessionFactoriesManager;

        private readonly ILogger _logger;

        private readonly static object _lock = new object();

        private ISessionFactory _sessionFactory
        {
            get
            {
                return (ISessionFactory)_sessionFactoriesManager.GetEntitySessionFactory<T>();
            }
        }

        //private ISession _currentSession { get { return ((ISessionFactory)_sessionFactoriesManager.GetEntitySessionFactory<T>()).GetCurrentSession(); } }

        private ISession _currentSession
        {
            get
            {
                var session = _sessionFactoriesManager.GetCurrentSession<T>() as ISession;
                if (session != null && (session.Transaction == null || !session.Transaction.IsActive))
                {
                    lock (_lock)
                    {
                        if (session != null && (session.Transaction == null || !session.Transaction.IsActive))
                        {
                            session.BeginTransaction();
                        }
                    }
                    
                }

                return session;
            }
        }

        #endregion


        #region Constructors

        public Repository(ISessionFactoriesManager sessionFactoriesManager, ILogger logger)
        {
            if (sessionFactoriesManager == null)
                throw new ArgumentNullException("sessionFactoriesManager");

            if (logger == null)
                throw new ArgumentNullException("logger");

            _logger = logger;
            //_sessionFactory = sessionFactory;
            _sessionFactoriesManager = sessionFactoriesManager;
        }

        #endregion

        #region Public Methods

        #region Get Count
        public int GetCount()
        {
            var criteria = _currentSession.CreateCriteria(typeof(T)).SetProjection(Projections.RowCount());
            return (int)criteria.UniqueResult();
        }

        public int GetCount(IQueryCriterion restrictions)
        {
            var criteria = _currentSession.CreateCriteria(typeof(T))

                .SetProjection(Projections.RowCount());//.SetResultTransformer(new DeepTransformer<T>());
            return (int)criteria.UniqueResult();
        }

        public int GetCount(Expression<Func<T, bool>> restrictions)
        {
            return _currentSession.QueryOver<T>().Where(restrictions).RowCount();
        }

        public int GetDistinctCount(IQueryCriterion restrictions, string distinctPropertyName)
        {
            var criteria =
                _currentSession
                .CreateCriteria(typeof(T))
                .Add(NhCriteriaBuilder<T>.GetCriteria(restrictions))
                .SetProjection(Projections.CountDistinct(distinctPropertyName));
            return (int)criteria.UniqueResult();
        }

        public int GetDistinctCount(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> distinctProperty)
        {
            return _currentSession.QueryOver<T>().Select(Projections.Distinct(Projections.Property(distinctProperty))).Where(restrictions).RowCount();
        }

        public async Task<int> GetCountAsync()
        {
            return await Task.Factory.StartNew(() => GetCount());
        }

        public async Task<int> GetCountAsync(IQueryCriterion restrictions)
        {
            return await Task.Factory.StartNew(() => GetCount(restrictions));
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> restrictions)
        {
            return await Task.Factory.StartNew(() => GetCount(restrictions));
        }

        public async Task<int> GetDistinctCountAsync(IQueryCriterion restrictions, string distinctPropertyName)
        {
            return await Task.Factory.StartNew(() => GetDistinctCount(restrictions, distinctPropertyName));
        }

        public async Task<int> GetDistinctCountAsync(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> distinctProperty)
        {
            return await Task.Factory.StartNew(() => GetDistinctCount(restrictions, distinctProperty));
        }
        #endregion


        #region Any

        public bool Any()
        {
            return GetCount() > 0;
        }

        public async Task<bool> AnyAsync()
        {
            return await Task.Factory.StartNew(() => Any());
        }

        public bool Any(IQueryCriterion restrictions)
        {
            return GetCount(restrictions) > 0;
        }

        public async Task<bool> AnyAsync(IQueryCriterion restrictions)
        {
            return await Task.Factory.StartNew(() => Any(restrictions));
        }

        public bool Any(Expression<Func<T, bool>> restrictions)
        {
            return GetCount(restrictions) > 0;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> restrictions)
        {
            return await Task.Factory.StartNew(() => Any(restrictions));
        }

        #endregion

        #region Get Element By Id
        public T Get(object id)
        {
            return _currentSession.Get<T>(id);
        }

        public T Get(object id, params Expression<Func<T, object>>[] projections)
        {
            return _currentSession.Get<T>(id);
        }

        public async Task<T> GetAsync(object id)
        {
            return await Task.Factory.StartNew(() => _currentSession.Get<T>(id));
        }
        #endregion



        #region Get All
        public IEnumerable<T> GetAll()
        {
            return _currentSession.CreateCriteria(typeof(T)).List<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => GetAll());
        }


        public IEnumerable<T> GetAll(Order order)
        {
            return _currentSession.CreateCriteria(typeof(T)).AddOrder(order).List<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Order order)
        {
            return await Task.Factory.StartNew(() => GetAll(order));
        }

        public IEnumerable<T> GetAllOrderBy(Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            return ascending
                ? _currentSession.QueryOver<T>().OrderBy(orderByProperty).Asc.List()
                : _currentSession.QueryOver<T>().OrderBy(orderByProperty).Desc.List();
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            return await Task.Factory.StartNew(() => GetAllOrderBy(orderByProperty, ascending));
        }


        public IEnumerable<T> GetAll(IQueryCriterion restrictions)
        {
            return _currentSession
                .CreateCriteria(typeof(T))
                .Add(NhCriteriaBuilder<T>.GetCriteria(restrictions))
                .List<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(IQueryCriterion restrictions)
        {
            return await Task.Factory.StartNew(() => GetAll(restrictions));
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> restrictions)
        {
            return _currentSession.QueryOver<T>().Where(restrictions).List();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> restrictions)
        {
            return await Task.Factory.StartNew(() => GetAll(restrictions));
        }


        public IEnumerable<T> GetAllOrderBy(Order order, IQueryCriterion restrictions)
        {
            return _currentSession
                .CreateCriteria(typeof(T))
                .AddOrder(order)
                .Add(NhCriteriaBuilder<T>.GetCriteria(restrictions))
                .List<T>();
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Order order, IQueryCriterion restrictions)
        {
            return await Task.Factory.StartNew(() => GetAllOrderBy(order, restrictions));
        }

        public IEnumerable<T> GetAllOrderBy(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {

            var query = _currentSession.QueryOver<T>().Where(restrictions);
            return ascending
                ? query.OrderBy(orderByProperty).Asc.List()
                : query.OrderBy(orderByProperty).Desc.List();
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {

            return await Task.Factory.StartNew(() => GetAllOrderBy(restrictions, orderByProperty, ascending));
        }


        //public IEnumerable<T> GetAll(params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .List<T>();
        //}

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] projections)
        {
            return _currentSession.QueryOver<T>().Select(projections).List();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetAll(projections));
        }

        //public IEnumerable<Q> GetAllProjected<Q>(params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .Future<Q>();
        //}

        //public IEnumerable<Q> GetAllProjected<Q>(params Expression<Func<T, object>>[] projections)
        //{
        //    return _currentSession.QueryOver<T>().Select(projections).Future<Q>();
        //}


        //public IEnumerable<T> GetAll(Order order, params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .AddOrder(order)
        //        .List<T>();
        //}

        public IEnumerable<T> GetAllOrderBy(Expression<Func<T, object>> orderByProperty, bool ascending, params Expression<Func<T, object>>[] projections)
        {
            var orderByQuery = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>()).OrderBy(orderByProperty);
            return ascending
                ? orderByQuery.Asc.List<T>()
                : orderByQuery.Desc.List<T>();
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, object>> orderByProperty, bool ascending, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetAllOrderBy(orderByProperty, ascending, projections));
        }

        //public IEnumerable<Q> GetAll<Q>(Order order, params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .AddOrder(order)
        //        .Future<Q>();
        //}

        //public IEnumerable<Q> GetAll<Q>(Expression<Func<T, object>> orderByProperty, bool ascending, params Expression<Func<T, object>>[] projections)
        //{
        //    var orderByQuery = _currentSession.QueryOver<T>().Select(projections).OrderBy(orderByProperty);
        //    return ascending
        //        ? orderByQuery.Asc.Future<Q>()
        //        : orderByQuery.Desc.Future<Q>();
        //}


        //public IEnumerable<T> GetAll(ICriterion restrictions, params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .Add(restrictions)
        //        .List<T>();
        //}

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        {
            return _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>()).Where(restrictions).List();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetAll(restrictions, projections));
        }

        public IEnumerable<T> GetAll(IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections)
        {
            return _currentSession.QueryOver<T>()
                        .SelectList(list => GetSelectList(projections))
                        .TransformUsing(new DeepTransformer<T>())
                        .Where(NhCriteriaBuilder<T>.GetCriteria(restrictions))
                        .List<T>();

        }
        public async Task<IEnumerable<T>> GetAllAsync(IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetAll(restrictions, projections));
        }


        //public IEnumerable<Q> GetAllProjected<Q>(ICriterion restrictions, params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .Add(restrictions)
        //        .Future<Q>();
        //}

        //public IEnumerable<Q> GetAllProjected<Q>(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        //{
        //    return _currentSession.QueryOver<T>().Select(projections).Where(restrictions).Future<Q>();
        //}


        //public IEnumerable<T> GetAll(Order order, ICriterion restrictions, params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .Add(restrictions)
        //        .AddOrder(order)
        //        .List<T>();
        //}

        public IEnumerable<T> GetAllOrderBy(Expression<Func<T, object>> orderByProperty, bool ascending, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        {
            var orderByQuery = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>()).Where(restrictions).OrderBy(orderByProperty);
            return ascending
                ? orderByQuery.Asc.List()
                : orderByQuery.Desc.List();
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, object>> orderByProperty, bool ascending, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetAllOrderBy(orderByProperty, ascending, restrictions, projections));
        }




        //public IEnumerable<Q> GetAll<Q>(Order order, ICriterion restrictions, params IProjection[] projections)
        //{
        //    return _currentSession
        //        .CreateCriteria(typeof(T))
        //        .SetProjection(projections)
        //        .Add(restrictions)
        //        .AddOrder(order)
        //        .Future<Q>();
        //}

        //public IEnumerable<Q> GetAll<Q>(Expression<Func<T, object>> orderByProperty, bool ascending, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        //{
        //    var orderByQuery = _currentSession.QueryOver<T>().Select(projections).Where(restrictions).OrderBy(orderByProperty);
        //    return ascending
        //        ? orderByQuery.Asc.Future<Q>()
        //        : orderByQuery.Desc.Future<Q>();
        //}
        #endregion

        #region Get With Skip and Take
        public IEnumerable<T> GetSkipAndTake(int skip, int take)
        {
            return take <= 0
                ? skip <= 0
                    ? _currentSession.QueryOver<T>().List()
                    : new List<T>()
                : _currentSession.QueryOver<T>().Skip(skip).Take(take).List();
        }


        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take));
        }

        public IEnumerable<T> GetSkipAndTake(int skip, int take, IQueryCriterion restrictions)
        {
            var query = _currentSession.QueryOver<T>().Where(NhCriteriaBuilder<T>.GetCriteria(restrictions));
            return take <= 0
                ? skip <= 0
                    ? query.List()
                    : new List<T>()
                : query.Skip(skip).Take(take).List();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, IQueryCriterion restrictions)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take, restrictions));
        }

        public IEnumerable<T> GetSkipAndTake(int skip, int take, Expression<Func<T, bool>> restrictions)
        {
            var query = _currentSession.QueryOver<T>().Where(restrictions);
            return take <= 0
                ? skip <= 0
                    ? query.List()
                    : new List<T>()
                : query.Skip(skip).Take(take).List();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, Expression<Func<T, bool>> restrictions)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take, restrictions));
        }

        public IEnumerable<T> GetSkipAndTake(int skip, int take, Expression<Func<T, bool>> restrictions, IQueryCriterion additionalRestrictions)
        {
            var query = _currentSession.QueryOver<T>().Where(restrictions).And(NhCriteriaBuilder<T>.GetCriteria(additionalRestrictions));
            return take <= 0
                ? skip <= 0
                    ? query.List()
                    : new List<T>()
                : query.Skip(skip).Take(take).List();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, Expression<Func<T, bool>> restrictions, IQueryCriterion additionalRestrictions)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take, restrictions, additionalRestrictions));
        }

        //public IEnumerable<T> GetSkipAndTake(int skip, int take, params IProjection[] projections)
        //{
        //    var query = _currentSession.QueryOver<T>().Select(projections);
        //    return take <= 0
        //        ? skip <= 0
        //            ? query.Future()
        //            : new List<T>()
        //        : query.Skip(skip).Take(take).Future();
        //}

        //public IEnumerable<Q> GetSkipAndTake<Q>(int skip, int take, params IProjection[] projections)
        //{
        //    var query = _currentSession.QueryOver<T>().Select(projections);
        //    return take <= 0
        //        ? skip <= 0
        //            ? query.Future<Q>()
        //            : new List<Q>()
        //        : query.Skip(skip).Take(take).Future<Q>();
        //}

        public IEnumerable<T> GetSkipAndTake(int skip, int take, params Expression<Func<T, object>>[] projections)
        {

            var query = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>());
            var result = take <= 0
                ? skip <= 0
                    ? query.List<T>()
                    : new List<T>()
                : query.Skip(skip).Take(take).List<T>();

            return result;
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take, projections));
        }

        public IEnumerable<T> GetSkipAndTake(int skip, int take, IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections)
        {
            var query = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>()).Where(NhCriteriaBuilder<T>.GetCriteria(restrictions));
            return take <= 0
                ? skip <= 0
                    ? query.List<T>()
                    : new List<T>()
                : query.Skip(skip).Take(take).List<T>();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take, restrictions, projections));
        }

        public IEnumerable<T> GetSkipAndTake(int skip, int take, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        {
            var query = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>()).Where(restrictions);
            return take <= 0
                ? skip <= 0
                    ? query.List<T>()
                    : new List<T>()
                : query.Skip(skip).Take(take).List<T>();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTake(skip, take, restrictions, projections));
        }

        public IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            var query = ascending
                ? _currentSession.QueryOver<T>().OrderBy(orderByProperty).Asc
                : _currentSession.QueryOver<T>().OrderBy(orderByProperty).Desc;
            return take <= 0
                ? skip <= 0
                    ? query.List()
                    : new List<T>()
                : query.Skip(skip).Take(take).List();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTakeOrderBy(skip, take, orderByProperty, ascending));
        }

        public IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            var query = _currentSession.QueryOver<T>().Where(NhCriteriaBuilder<T>.GetCriteria(restrictions));

            query = ascending
                ? query.OrderBy(orderByProperty).Asc
                : query.OrderBy(orderByProperty).Desc;

            return take <= 0
                ? skip <= 0
                    ? query.List()
                    : new List<T>()
                : query.Skip(skip).Take(take).List();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTakeOrderBy(skip, take, restrictions, orderByProperty, ascending));
        }

        public IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            var query = _currentSession.QueryOver<T>().Where(restrictions);

            query = ascending
                ? query.OrderBy(orderByProperty).Asc
                : query.OrderBy(orderByProperty).Desc;

            return take <= 0
                ? skip <= 0
                    ? query.List()
                    : new List<T>()
                : query.Skip(skip).Take(take).List();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTakeOrderBy(skip, take, restrictions, orderByProperty, ascending));
        }




        public IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections)
        {
            var query = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).TransformUsing(new DeepTransformer<T>()).Where(restrictions);

            query = ascending
                ? query.OrderBy(orderByProperty).Asc
                : query.OrderBy(orderByProperty).Desc;

            return take <= 0
                ? skip <= 0
                    ? query.List<T>()
                    : new List<T>()
                : query.Skip(skip).Take(take).List<T>();
        }



        public async Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTakeOrderBy(skip, take, restrictions, orderByProperty, ascending, projections));
        }


        //http://www.andrewwhitaker.com/blog/2015/05/31/queryover-series-part-10-combining-criteria-and-queryover/
        public IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections)
        {
            var query = _currentSession.QueryOver<T>().SelectList(list => GetSelectList(projections)).Where(NhCriteriaBuilder<T>.GetCriteria(restrictions)).TransformUsing(new DeepTransformer<T>());

            query = ascending
                ? query.OrderBy(orderByProperty).Asc
                : query.OrderBy(orderByProperty).Desc;

            return take <= 0
                ? skip <= 0
                    ? query.List<T>()
                    : new List<T>()
                : query.Skip(skip).Take(take).List<T>();
        }

        public async Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections)
        {
            return await Task.Factory.StartNew(() => GetSkipAndTakeOrderBy(skip, take, restrictions, orderByProperty, ascending, projections));
        }

        #endregion

        #region Add
        public bool Add(T item)
        {
            var isReadOnly = IsReadOnlyEntity();
            if (isReadOnly.HasValue && isReadOnly.Value)
                ThrowReadOnlyException();
            if (item == null)
                throw new ArgumentNullException();

            //LogDbAction("Adding", item);
            item.SetDefaultValues();
            item.CreationTime = DateTime.Now;
            item.UpdatedTime = DateTime.Now;
            _currentSession.Save(item);

            var transaction = _currentSession.Transaction;
            if (transaction != null || transaction.IsActive)
            {
                transaction.Commit();
                _currentSession.BeginTransaction();
            }

            return true;
        }

        public async Task<bool> AddAsync(T item)
        {
            return await Task.Factory.StartNew(() => Add(item));
        }

        #endregion

        #region Update
        public bool Update(T item)
        {
            var isReadOnly = IsReadOnlyEntity();
            if (isReadOnly.HasValue && isReadOnly.Value)
                ThrowReadOnlyException();
            if (item == null)
                throw new ArgumentNullException();
            //LogDbAction("Updating", item);

            item.UpdatedTime = DateTime.Now;
            _currentSession.Update(item);
            return true;
        }



        public void UpdateAndCommit(T item)
        {
            var isReadOnly = IsReadOnlyEntity();
            if (isReadOnly.HasValue && isReadOnly.Value)
                ThrowReadOnlyException();
            if (item == null)
                throw new ArgumentNullException();

            item.UpdatedTime = DateTime.Now;
            _currentSession.Update(item);
            var transaction = _currentSession.Transaction;
            if (transaction != null || transaction.IsActive)
            {
                transaction.Commit();
                _currentSession.BeginTransaction();
            }
        }

        public async Task<bool> UpdateAsync(T item)
        {
            return await Task.Factory.StartNew(() => Update(item));
        }

        public async Task UpdateAndCommitAsync(T item)
        {
            await Task.Factory.StartNew(() => UpdateAndCommit(item));
        }
        #endregion

        #region Delete
        public void Delete(object id)
        {
            var isReadOnly = IsReadOnlyEntity();
            if (isReadOnly.HasValue && isReadOnly.Value)
                ThrowReadOnlyException();
            var item = Get(id);

            if (item == null) return;

            //LogDbAction("Deleting", item);
            _currentSession.Delete(item);
        }

        public async Task DeleteAsync(object id)
        {
            await Task.Factory.StartNew(() => Delete(id));
        }

        public void Delete(T item)
        {
            var isReadOnly = IsReadOnlyEntity();
            if (isReadOnly.HasValue && isReadOnly.Value)
                ThrowReadOnlyException();


            if (item == null)
                return;

            //LogDbAction("Deleting", item);
            _currentSession.Delete(item);
        }


        public async Task DeleteAsync(T item)
        {
            await Task.Factory.StartNew(() => Delete(item));
        }


        #endregion


        #endregion Public Methods


        private void LogDbAction(string action, T t)
        {
            var sb = new StringBuilder();
            sb.Append(action);
            sb.AppendLine(" Object : ");
            sb.Append(typeof(T));
            sb.AppendLine(" Values =>{ ##################################");
            foreach (var prop in typeof(T).GetProperties())
            {
                sb.Append(prop.Name);
                sb.Append(" = ");
                sb.AppendLine(prop.GetValue(t) != null ? prop.GetValue(t).ToString() : "null");
            }
            sb.AppendLine("################################## }");

            _logger.LogInfo(sb.ToString());
        }

        private static QueryOverProjectionBuilder<T> GetSelectList(Expression<Func<T, object>>[] projections)
        {
            var qopb = new QueryOverProjectionBuilder<T>();

            foreach (var projection in projections)
            {
                var projectionProperty = Projections.Property(projection);
                var simpleProjectionProperty = projectionProperty.As(projectionProperty.PropertyName/*.Replace(".", "_")*/);
                var convertedProp = LinqExpressions.Lambda<Func<object>>(projection.Body);
                qopb.Select(simpleProjectionProperty);//.WithAlias(convertedProp);
            }
            return qopb;
        }

        private static void ThrowReadOnlyException(T item)
        {
            throw new InvalidOperationException(String.Format("This Entity \"{0}\" is set as Read only, you should either set it`s ReadOnly flag to false or remove this action", item.GetType().Name));
        }

        private static void ThrowReadOnlyException()
        {
            throw new InvalidOperationException(String.Format("This Entity \"{0}\" is set as Read only, you should either set it`s ReadOnly flag to false or remove this action", (typeof(T)).Name));
        }

        private static bool? IsReadOnlyEntity()
        {
            return Attribute.IsDefined(typeof(T), typeof(DBTableAttribute)) ? (bool?)(typeof(T).GetCustomAttribute<DBTableAttribute>().ReadOnly) : null;
        }
        
    }
}
