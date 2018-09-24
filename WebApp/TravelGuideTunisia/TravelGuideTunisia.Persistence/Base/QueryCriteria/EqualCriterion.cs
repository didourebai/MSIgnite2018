using System;
using System.Linq.Expressions;

namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class EqualCriterion<A> : IQueryCriterion
    {
        public Expression<Func<A, object>> PropertyExpression { get; set; }

        public object Value;

        public string PropertyName
        {
            get
            {
                return PropertyExpression.Body is UnaryExpression
                ? ((MemberExpression)((UnaryExpression)PropertyExpression.Body).Operand).Member.Name
                : ((MemberExpression)(PropertyExpression.Body)).Member.Name;
            }
        }

        public EqualCriterion(Expression<Func<A, object>> propertyExpression, object value)
        {
            PropertyExpression = propertyExpression;
            Value = value;
        }
    }
}
