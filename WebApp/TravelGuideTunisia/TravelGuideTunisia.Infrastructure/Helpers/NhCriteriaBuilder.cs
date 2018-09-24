using System;
using System.Linq.Expressions;
using NHibernate.Impl;
using TravelGuideTunisia.Persistence.Base.Classes;
using TravelGuideTunisia.Persistence.Base.QueryCriteria;
using TravelGuideTunisia.Persistence.Base.QueryCriteria.Enums;
using NHCriterion = NHibernate.Criterion;
using Criteria = TravelGuideTunisia.Persistence.Base.QueryCriteria;

namespace TravelGuideTunisia.Infrastructure.Helpers
{
    public static class NhCriteriaBuilder<A> where A : BasicEntity
    {
        public static NHCriterion.ICriterion GetCriteria(IQueryCriterion criterion)
        {

            if (criterion is Criteria.Conjunction)
            {
                return GetConjunction(criterion);
            }
            if (criterion is Criteria.Disjunction)
            {
                return GetDisjunction(criterion);
            }
            if (criterion is NotCriterion<A>)
            {
                return SetAsNot(criterion);

            }
            if (criterion is LikeCriterion<A>)
            {
                return GetLike(criterion);
            }
            if (criterion is NullCriterion<A>)
            {
                return GetNull(criterion);
            }
            if (criterion is NotNullCriterion<A>)
            {
                return GetNotNull(criterion);
            }
            if (criterion is EqualCriterion<A>)
            {
                return GetEqual(criterion);
            }
            if (criterion is GreaterThanCriterion<A>)
            {
                return GetGreaterThan(criterion);
            }
            if (criterion is LessThanCriterion<A>)
            {
                return GetLessThan(criterion);
            }
            if (criterion is NotLikeCriterion<A>)
            {
                return GetNotLike(criterion);
            }
            if (criterion is InCriterion<A>)
            {
                return GetIn(criterion);
            }
            throw new NotImplementedException(String.Format("There is no Conversion for this Type {0}. Come-one and implement it yourself!", criterion.GetType().FullName));



        }

        public static NHCriterion.ICriterion GetCriteria<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {

            if (criterion is Criteria.Conjunction)
            {
                return GetConjunction(criterion, alias);
            }
            if (criterion is Criteria.Disjunction)
            {
                return GetDisjunction(criterion, alias);
            }
            if (criterion is NotCriterion<A>)
            {
                return SetAsNot(criterion, alias);

            }
            if (criterion is LikeCriterion<A>)
            {
                return GetLike(criterion, alias);
            }
            if (criterion is NullCriterion<A>)
            {
                return GetNull(criterion, alias);
            }
            if (criterion is NotNullCriterion<A>)
            {
                return GetNotNull(criterion, alias);
            }
            if (criterion is EqualCriterion<A>)
            {
                return GetEqual(criterion, alias);
            }
            if (criterion is GreaterThanCriterion<A>)
            {
                return GetGreaterThan(criterion, alias);
            }
            if (criterion is LessThanCriterion<A>)
            {
                return GetLessThan(criterion, alias);
            }
            if (criterion is NotLikeCriterion<A>)
            {
                return GetNotLike(criterion, alias);
            }
            throw new NotImplementedException(String.Format("There is no Conversion for this Type {0}. Come-one and implement it yourself!", criterion.GetType().FullName));
        }


        public static NHCriterion.IProjection GetOrderByProjection<B>(Expression<Func<A, object>> orderByProperty, Expression<Func<B>> alias)
        {
            var orderByPropertyName = orderByProperty.Body is UnaryExpression
                ? ((MemberExpression)((UnaryExpression)orderByProperty.Body).Operand).Member.Name
                : ((MemberExpression)(orderByProperty.Body)).Member.Name;

            var aliasName = ExpressionProcessor.FindMemberExpression(alias.Body);
            return NHCriterion.Projections.Property(String.Format("{0}.{1}", aliasName, orderByPropertyName));
        }

        private static NHCriterion.ICriterion SetAsNot(IQueryCriterion criterion)
        {
            var notCriterion = criterion as NotCriterion<A>;
            return NHCriterion.Restrictions.Not(GetCriteria(notCriterion.Criterion));
        }

        private static NHCriterion.ICriterion SetAsNot<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var notCriterion = criterion as NotCriterion<A>;
            return NHCriterion.Restrictions.Not(GetCriteria(notCriterion.Criterion, alias));
        }

        private static NHCriterion.ICriterion GetEqual(IQueryCriterion criterion)
        {
            var eqCriterion = criterion as Criteria.EqualCriterion<A>;
            var projection = NHCriterion.Projections.Property<A>(eqCriterion.PropertyExpression);
            return NHCriterion.Restrictions.Eq(projection, eqCriterion.Value);
        }

        private static NHCriterion.ICriterion GetEqual<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            string aliasName = ExpressionProcessor.FindMemberExpression(alias.Body);

            var eqCriterion = criterion as Criteria.EqualCriterion<A>;
            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), eqCriterion.PropertyName);

            return NHCriterion.Restrictions.Eq(propertyName, eqCriterion.Value);
        }

        private static NHCriterion.ICriterion GetNotNull(IQueryCriterion criterion)
        {
            var notNull = criterion as NotNullCriterion<A>;
            var projection = NHCriterion.Projections.Property<A>(notNull.PropertyExpression);
            return NHCriterion.Restrictions.IsNotNull(projection);
        }

        private static NHCriterion.ICriterion GetNotLike(IQueryCriterion criterion)
        {
            var notLikeCriterion = criterion as NotLikeCriterion<A>;
            return notLikeCriterion.Insensitive
                 ? NHCriterion.Restrictions.On<A>(notLikeCriterion.PropertyExpression).IsInsensitiveLike(notLikeCriterion.Value, GetNHMatchMode(notLikeCriterion.MatchMode))
                 : NHCriterion.Restrictions.On<A>(notLikeCriterion.PropertyExpression).IsLike(notLikeCriterion.Value, GetNHMatchMode(notLikeCriterion.MatchMode));
        }

        private static NHCriterion.ICriterion GetNotLike<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var notLikeCriterion = criterion as NotLikeCriterion<A>; ;
            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), notLikeCriterion.PropertyName);
            return NHCriterion.Restrictions.Not(notLikeCriterion.Insensitive
                ? NHCriterion.Restrictions.InsensitiveLike(propertyName, notLikeCriterion.Value, GetNHMatchMode(notLikeCriterion.MatchMode))
                : NHCriterion.Restrictions.Like(propertyName, notLikeCriterion.Value, GetNHMatchMode(notLikeCriterion.MatchMode)));
        }

        private static NHCriterion.ICriterion GetNotNull<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var notNull = criterion as NotNullCriterion<A>; ;
            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), notNull.PropertyName);
            return NHCriterion.Restrictions.IsNotNull(propertyName);
        }

        private static NHCriterion.ICriterion GetNull(IQueryCriterion criterion)
        {
            var isNull = criterion as NullCriterion<A>;
            var projection = NHCriterion.Projections.Property<A>(isNull.PropertyExpression);
            return NHCriterion.Restrictions.IsNull(projection);
        }

        private static NHCriterion.ICriterion GetNull<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var isNull = criterion as NullCriterion<A>;
            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), isNull.PropertyName);

            return NHCriterion.Restrictions.IsNull(propertyName);
        }

        private static NHCriterion.ICriterion GetLike(IQueryCriterion criterion)
        {
            var likeCriterion = criterion as LikeCriterion<A>;

            return likeCriterion.Insensitive
                ? NHCriterion.Restrictions.On<A>(likeCriterion.PropertyExpression).IsInsensitiveLike(likeCriterion.Value, GetNHMatchMode(likeCriterion.MatchMode))
                : NHCriterion.Restrictions.On<A>(likeCriterion.PropertyExpression).IsLike(likeCriterion.Value, GetNHMatchMode(likeCriterion.MatchMode));
        }

        private static NHCriterion.ICriterion GetLike<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var likeCriterion = criterion as LikeCriterion<A>;
            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), likeCriterion.PropertyName);
            return likeCriterion.Insensitive
                ? NHCriterion.Restrictions.InsensitiveLike(propertyName, likeCriterion.Value, GetNHMatchMode(likeCriterion.MatchMode))
                : NHCriterion.Restrictions.Like(propertyName, likeCriterion.Value, GetNHMatchMode(likeCriterion.MatchMode));
        }

        private static NHCriterion.ICriterion GetDisjunction(IQueryCriterion criterion)
        {
            var domainDisjunction = criterion as Criteria.Disjunction;
            var nHDisjunction = new NHCriterion.Disjunction();
            foreach (var subCriterion in domainDisjunction.Criteria)
            {
                nHDisjunction.Add(GetCriteria(subCriterion));
            }
            return nHDisjunction;
        }

        private static NHCriterion.ICriterion GetDisjunction<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var domainDisjunction = criterion as Criteria.Disjunction;
            var nHDisjunction = new NHCriterion.Disjunction();
            foreach (var subCriterion in domainDisjunction.Criteria)
            {
                nHDisjunction.Add(GetCriteria(subCriterion, alias));
            }
            return nHDisjunction;
        }

        private static NHCriterion.ICriterion GetConjunction(IQueryCriterion criterion)
        {
            var domainConjunction = criterion as Criteria.Conjunction;
            var nHConjunction = new NHCriterion.Conjunction();
            foreach (var subCriterion in domainConjunction.Criteria)
            {
                nHConjunction.Add(GetCriteria(subCriterion));
            }
            return nHConjunction;
        }

        private static NHCriterion.ICriterion GetConjunction<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var domainConjunction = criterion as Criteria.Conjunction;
            var nHConjunction = new NHCriterion.Conjunction();
            foreach (var subCriterion in domainConjunction.Criteria)
            {
                nHConjunction.Add(GetCriteria(subCriterion, alias));
            }
            return nHConjunction;
        }

        private static NHCriterion.ICriterion GetGreaterThan(IQueryCriterion criterion)
        {
            var gtCriterion = criterion as GreaterThanCriterion<A>;
            var projection = NHCriterion.Projections.Property<A>(gtCriterion.PropertyExpression);
            return gtCriterion.AcceptEqual
                ? NHCriterion.Restrictions.Ge(projection, gtCriterion.Value)
                : NHCriterion.Restrictions.Gt(projection, gtCriterion.Value);
        }

        private static NHCriterion.ICriterion GetGreaterThan<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var gtCriterion = criterion as GreaterThanCriterion<A>;
            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), gtCriterion.PropertyName);
            return gtCriterion.AcceptEqual
                ? NHCriterion.Restrictions.Ge(propertyName, gtCriterion.Value)
                : NHCriterion.Restrictions.Gt(propertyName, gtCriterion.Value);
        }

        private static NHCriterion.ICriterion GetLessThan(IQueryCriterion criterion)
        {
            var ltCriterion = criterion as GreaterThanCriterion<A>;
            var projection = NHCriterion.Projections.Property<A>(ltCriterion.PropertyExpression);
            return ltCriterion.AcceptEqual
                ? NHCriterion.Restrictions.Le(projection, ltCriterion.Value)
                : NHCriterion.Restrictions.Lt(projection, ltCriterion.Value);
        }

        private static NHCriterion.ICriterion GetLessThan<B>(IQueryCriterion criterion, Expression<Func<B>> alias) where B : BasicEntity
        {
            var ltCriterion = criterion as GreaterThanCriterion<A>;

            string propertyName = string.Format("{0}.{1}", ExpressionProcessor.FindMemberExpression(alias.Body), ltCriterion.PropertyName);
            return ltCriterion.AcceptEqual
                ? NHCriterion.Restrictions.Le(propertyName, ltCriterion.Value)
                : NHCriterion.Restrictions.Lt(propertyName, ltCriterion.Value);
        }

        private static NHCriterion.ICriterion GetIn(IQueryCriterion criterion)
        {
            var inCriterion = criterion as InCriterion<A>;
            var projection = NHCriterion.Projections.Property(inCriterion.PropertyExpression);
            return NHCriterion.Restrictions.InG(projection, inCriterion.Values);
        }

        private static NHibernate.Criterion.MatchMode GetNHMatchMode(MatchingMode matchingMode)
        {
            switch (matchingMode)
            {
                case MatchingMode.Exact:
                    return NHCriterion.MatchMode.Exact;
                case MatchingMode.Start:
                    return NHCriterion.MatchMode.Start;
                case MatchingMode.End:
                    return NHCriterion.MatchMode.End;
                case MatchingMode.Anywhere:
                    return NHCriterion.MatchMode.Anywhere;
                default:
                    return NHCriterion.MatchMode.Exact;
            }
        }

    }
}
