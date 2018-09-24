using System;
using System.Linq.Expressions;
using TravelGuideTunisia.Persistence.Base.QueryCriteria.Enums;

namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class NotLikeCriterion<A> : IQueryCriterion
    {

        public bool Insensitive { get; set; }

        public MatchingMode MatchMode { get; set; }

        public Expression<Func<A, object>> PropertyExpression { get; set; }

        public string PropertyName
        {
            get
            {
                return PropertyExpression.Body is UnaryExpression
                ? ((MemberExpression)((UnaryExpression)PropertyExpression.Body).Operand).Member.Name
                : ((MemberExpression)(PropertyExpression.Body)).Member.Name;
            }
        }

        public string Value;

        public NotLikeCriterion(Expression<Func<A, object>> propertyExpression, string value)
        {
            PropertyExpression = propertyExpression;
            MatchMode = MatchingMode.Exact;
            Value = value;
        }

        public NotLikeCriterion(Expression<Func<A, object>> propertyExpression, string value, bool insensitive)
        {
            PropertyExpression = propertyExpression;
            MatchMode = MatchingMode.Exact;
            Insensitive = insensitive;
            Value = value;
        }

        public NotLikeCriterion(Expression<Func<A, object>> propertyExpression, string value, MatchingMode matchMode)
        {
            PropertyExpression = propertyExpression;
            Value = value;
            MatchMode = matchMode;
        }

        public NotLikeCriterion(Expression<Func<A, object>> propertyExpression, string value, bool insensitive, MatchingMode matchMode)
        {
            PropertyExpression = propertyExpression;
            Value = value;
            MatchMode = matchMode;
            Insensitive = insensitive;
        }
    }
}
