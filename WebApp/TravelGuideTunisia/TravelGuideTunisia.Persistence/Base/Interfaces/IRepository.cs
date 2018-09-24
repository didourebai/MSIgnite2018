using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelGuideTunisia.Persistence.Base.Classes;
using TravelGuideTunisia.Persistence.Base.QueryCriteria;

namespace TravelGuideTunisia.Persistence.Base.Interfaces
{
    public interface IRepository<T>
         where T : BasicEntity
    {

        #region Get Count
        /// <summary>
        /// Count the number of entries.
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// Count the number of entries for a specific criteria.
        /// </summary>
        /// <param name="restrictions">The criteria (Restriction)</param>
        /// <returns></returns>
        int GetCount(IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(Expression<Func<T, bool>> restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="distinctPropertyName"></param>
        /// <returns></returns>
        int GetDistinctCount(IQueryCriterion restrictions, string distinctPropertyName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="distinctPropertyName"></param>
        /// <returns></returns>
        Task<int> GetDistinctCountAsync(IQueryCriterion restrictions, string distinctPropertyName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="distinctProperty"></param>
        /// <returns></returns>
        int GetDistinctCount(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> distinctProperty);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="distinctProperty"></param>
        /// <returns></returns>
        Task<int> GetDistinctCountAsync(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> distinctProperty);
        #endregion


        #region Any

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Any();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> AnyAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        bool Any(IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> restrictions);
        #endregion


        #region Get Element By Id
        /// <summary>
        /// Get an object T by its id
        /// </summary>
        /// <param name="id">The object id</param>
        /// <returns>Object T</returns>
        T Get(object id);
        #endregion

        #region Get Element By Id Async
        /// <summary>
        /// Get an object T by its id
        /// </summary>
        /// <param name="id">The object id</param>
        /// <returns>Object T</returns>
        Task<T> GetAsync(object id);
        #endregion


        #region Get All
        /// <summary>
        /// Get a list of objects of type T.
        /// </summary>
        /// <returns>List of objects</returns>
        IEnumerable<T> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        //IEnumerable<T> GetAll(Order order);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<T> GetAllOrderBy(Expression<Func<T, object>> orderByProperty, bool ascending = false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(IQueryCriterion restrictions);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> restrictions);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        //IEnumerable<T> GetAll(Order order, ICriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="order"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<T> GetAllOrderBy(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> order, bool ascending = false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="order"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> order, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<T> GetAll(params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetAllProjected<Q>(params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetAllProjected<Q>(params Expression<Func<T, object>>[] projections);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<T> GetAll(Order order, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetAllOrderBy(Expression<Func<T, object>> orderByProperty, bool ascending, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, object>> orderByProperty, bool ascending, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<T> GetAll(ICriterion restrictions, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetAllProjected<Q>(ICriterion restrictions, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetAllProjected<Q>(Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<T> GetAll(Order order, ICriterion restrictions, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ascending"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetAllOrderBy(Expression<Func<T, object>> orderByProperty, bool ascending, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, object>> orderByProperty, bool ascending, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);
        #endregion

        #region Get With Skip and Take
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take, IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, IQueryCriterion restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take, Expression<Func<T, bool>> restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, Expression<Func<T, bool>> restrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="additionalRestrictions"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take, Expression<Func<T, bool>> restrictions, IQueryCriterion additionalRestrictions);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="additionalRestrictions"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, Expression<Func<T, bool>> restrictions, IQueryCriterion additionalRestrictions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<T> GetSkipAndTake(int skip, int take, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetSkipAndTake<Q>(int skip, int take, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="additionalRestrictions"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetSkipAndTake<Q>(int skip, int take, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<T> GetSkipAndTake(int skip, int take, ICriterion restrictions, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetSkipAndTake<Q>(int skip, int take, ICriterion restrictions, params IProjection[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take, IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, IQueryCriterion restrictions, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTake(int skip, int take, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeAsync(int skip, int take, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        //IEnumerable<Q> GetSkipAndTake<Q>(int skip, int take, Expression<Func<T, bool>> restrictions, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, Expression<Func<T, bool>> restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        IEnumerable<T> GetSkipAndTakeOrderBy(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections);


        //IEnumerable<T> GetSkipAndTakeOrderBy<U>(int skip, int take, IQueryCriterion restrictions, JoinQueryParams<T, U> joinQueryParams, params Expression<Func<T, object>>[] projections) where U : BasicEntity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="restrictions"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="ascending"></param>
        /// <param name="projections"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSkipAndTakeOrderByAsync(int skip, int take, IQueryCriterion restrictions, Expression<Func<T, object>> orderByProperty, bool ascending = false, params Expression<Func<T, object>>[] projections);
        #endregion

        #region Add
        /// <summary>
        /// Add new object T.
        /// </summary>
        /// <param name="item">The object to add</param>
        /// <returns>true or false</returns>
        bool Add(T item);

        Task<bool> AddAsync(T item);
        #endregion

        #region Update
        /// <summary>
        /// Update an object T.
        /// </summary>
        /// <param name="item">The object to update</param>
        bool Update(T item);

        Task<bool> UpdateAsync(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void UpdateAndCommit(T item);

        Task UpdateAndCommitAsync(T item);
        #endregion

        #region Delete
        /// <summary>
        /// Delete an object by its id.
        /// </summary>
        /// <param name="id">The object id.</param>
        void Delete(object id);

        Task DeleteAsync(object id);

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task DeleteAsync(T item);
        #endregion

    }
}
