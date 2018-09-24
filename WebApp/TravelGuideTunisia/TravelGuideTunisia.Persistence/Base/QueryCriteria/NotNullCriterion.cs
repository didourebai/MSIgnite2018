using System;
using System.Linq.Expressions;

namespace TravelGuideTunisia.Persistence.Base.QueryCriteria
{
    public class NotNullCriterion<A> : IQueryCriterion
    {
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

        public NotNullCriterion(Expression<Func<A, object>> propertyExpression)
        {
            PropertyExpression = propertyExpression;
        }
    }
}
